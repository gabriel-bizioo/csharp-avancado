import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import axios from 'axios';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  titlePage="Products";
  products: [Product] | undefined;
  constructor() { }

  ngOnInit(): void 
  {  
    var config = {
      method: 'get',
      url: 'http://localhost:5118/product/getAll',
      headers: { }
    };

    var instance = this;
    
    axios(config)
    .then(function (response) {
      instance.products = response.data;
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
  }

  wishlist(bar_code:string){
    var data = '';

    var config = {
      method: 'post',
      url: 'http://localhost:5118/wishlist/create/' + localStorage.getItem("email") +'/' +  bar_code,
      headers: {},
      data: data
    };
    
    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        window.alert("AAAAAA");
      })
      .catch(function (error) {
        console.log(error);
      });
  }
}