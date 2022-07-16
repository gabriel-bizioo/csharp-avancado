import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import { Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  titlePage="Products";
  products: [Product] | undefined;
  constructor(private router: Router) { }

  ngOnInit(): void 
  {  
    var config = {
      method: 'get',
      url: 'http://localhost:5118/stock/get',
      headers: { }
    };

    var instance = this;
    
    axios(config)
    .then(function (response: any) {
      instance.products = response.data;
      console.log(response.data);
    })
    .catch(function (error: any) {
      console.log(error);
    });
  }

  wishlist(product: Product){
    
    let token = localStorage.getItem('authToken');

    var config = {
      method: 'post',
      url: `http://localhost:5118/wishlist/create/${localStorage.getItem("email")}/${product.barCode}/${product.storeId}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    };
    let instance = this;
    axios(config)
      .then(function (response: any) {
        console.log(JSON.stringify(response.data));
      })
      .catch(function (error: any) {

        //n ta aparecendo status 401
        if (error.response.status == 0) {
          instance.router.navigate(['/login']);
        }
      });
  }
}