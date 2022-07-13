import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import axios from 'axios';


@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.css']
})
export class WishListComponent implements OnInit 
{
  titlePage="Products";
  products : [Product] | undefined

  constructor() {}

  ngOnInit(): void 
  {    
    var config = {
      method: 'get',
      url: 'http://localhost:5118/wishlist/getproducts/' + localStorage.getItem("email"),
      headers: { }
    };
    
    let instance = this
    axios(config)
    .then(function (response) {
      instance.products = response.data;
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });
    
  }
}
