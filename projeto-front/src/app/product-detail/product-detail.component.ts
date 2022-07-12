import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Product} from '../products';
import axios from 'axios';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlepage= "ProductDetail"
  product : Product | undefined
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const RouteParams = this.route.snapshot.paramMap;
    const productIdfromRoute = Number(RouteParams.get('productID'));
    
    var config = {
      method: 'get',
      url: 'http://localhost:5118/product/get/' + productIdfromRoute,
      headers: { }
    };

    let instance = this;
    axios(config)
    .then(function (response) {
     instance.product = response.data;
     console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });
  }

  makePurchase(){
    var data = JSON.stringify({
      "confirmation_number": "this is a test",
      "number_nf": "this is a test",
      "payment_type": 1,
      "purchase_status": 1,
      "purchase_value": this.product?.price
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5118/purchase/create/000000/' + this.product?.bar_code + '/' + localStorage.getItem('email'),
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        window.alert("Eu quero dormir");
      })
      .catch(function (error) {
        console.log(error);
      });
  }

}