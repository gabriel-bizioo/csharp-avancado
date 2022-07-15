import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../products';
import axios from 'axios';

@Component({
  selector: 'app-register-product',
  templateUrl: './register-product.component.html',
  styleUrls: ['./register-product.component.css']
})
export class RegisterProductComponent implements OnInit {
  titlePage="Product Register"
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  registerProduct()
  {
    window.alert("Tome"); 
    let token = localStorage.getItem('authToken');
    let name = (document.getElementById('name') as HTMLInputElement).value;
    let barCode = (document.getElementById('barCode') as HTMLInputElement).value;

    var data = JSON.stringify({
      'name': name,
      'barCode': barCode,
      'img_link': 'asdsad'
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5118/product/register',
      data: data,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    axios(config)
    .then(function (response : any) {
      console.log(JSON.stringify(response.data));
      window.alert("Cadastrado");
    })
    .catch(function (error : any) {
      console.log(error);
      window.alert("Bostil falhou");
    });
  }

}
