import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import { ActivatedRoute } from '@angular/router';
import axios from 'axios';


@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.css']
})
export class WishListComponent implements OnInit {
  titlePage="Products";
  products : [Product] | undefined

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void 
  {
    const RouteParams = this.route.snapshot.paramMap;
    const clientIdfromRoute = Number(RouteParams.get('ClientID'));
    
    var config = {
      method: 'get',
      url: 'http://localhost:5118/wishlist/getproducts/' + localStorage.getItem("clientId"),
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
