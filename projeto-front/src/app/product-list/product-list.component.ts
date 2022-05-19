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
  constructor()
  {
    //this.getAllProducts();
  }

  ngOnInit(): void {
  }

  getAllProducts()
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
    })
    .catch(function (error) {
      console.log(error);
    });
  }


}