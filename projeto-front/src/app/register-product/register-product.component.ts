import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import axios from 'axios';
import { Store } from '../store';

@Component({
  selector: 'app-register-product',
  templateUrl: './register-product.component.html',
  styleUrls: ['./register-product.component.css']
})
export class RegisterProductComponent implements OnInit {
  titlePage="Product Register"
  constructor(private route: ActivatedRoute) { }
  userStores : [Store] | undefined;
  selectedStore : Store | undefined;

  ngOnInit(): void {
    let token = localStorage.getItem('authToken');
    let email = localStorage.getItem('email');

    var config = {
      method: 'get',
      url: 'http://localhost:5118/store/get/' + email,
      headers: {
      }
    };
    let instance = this;
    axios(config)
      .then(function (response: any) {
        console.log(JSON.stringify(response.data));
        instance.userStores = response.data;
        if(instance.userStores != undefined){
          instance.selectedStore = instance.userStores[0];
        }
      })
  }

  change(){
    let selectStore = (document.getElementById('store') as HTMLSelectElement).value

    this.userStores?.forEach(x => {
      if (x.name == selectStore) {
        this.selectedStore = x; 
      }
    })
  }


  registerProduct()
  {
    let token = localStorage.getItem('authToken');
    let name = (document.getElementById('name') as HTMLInputElement).value;
    let barCode = (document.getElementById('bar_code') as HTMLInputElement).value;
    let photo = (document.getElementById('photo') as HTMLInputElement).value;
    let quantity = (document.getElementById('quantity') as HTMLInputElement).value;
    let price = Number((document.getElementById('price') as HTMLInputElement).value);
    console.log(this.selectedStore?.name);

    var data = JSON.stringify({
      'name': name,
      'bar_code': barCode,
      'img_link': photo,
      'quantity': quantity,
      'unit_price': price,
      'store': {
        'cnpj': this.selectedStore?.cnpj
      }
    });


    var config = {
      method: 'post',
      url: 'http://localhost:5118/product/register',
      data: data,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    };

    axios(config)
    .then(function (response : any) {
      console.log(JSON.stringify(response.data));
      window.alert("Produto Cadastrado");
    })
    .catch(function (error : any) {
      console.log(error);
      window.alert("Erro no cadastro");
    });
  }
}
