import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import { Router } from '@angular/router';
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

  constructor(private router: Router) {}

  ngOnInit(): void 
  {    
    var token = localStorage.getItem('authToken');
    
    var config = {
      method: 'get',
      url: 'http://localhost:5118/wishlist/getproducts/' + localStorage.getItem("email"),
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    };
    
    let instance = this
    axios(config)
    .then(function (response: any) {
      instance.products = response.data;
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error: any) {
      console.log(error);
      if (error.response.status == 0){
        instance.router.navigate(['/login']) 
      }
    });
    
  }
}
