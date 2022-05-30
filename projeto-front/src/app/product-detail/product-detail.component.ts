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
}
