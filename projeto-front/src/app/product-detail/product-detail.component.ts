import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../products';
import axios from 'axios';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlepage= "Product Detail"
  product : Product | undefined
  constructor(private route: ActivatedRoute, private router: Router) { }

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
    let token = localStorage.getItem("authToken");
    
    var data = JSON.stringify({
      "payment_type": 1,
      "purchase_status": 1,
      "purchase_value": this.product?.price,
      "client": {
        "email": localStorage.getItem('email')
      },
      "product":{
        "bar_code": this.product?.barCode
      }
    });

    var config = {
      method: 'post',
      url: `http://localhost:5118/purchase/create/${this.product?.storeId}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      data: data
    };

    let instance = this;
    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        window.alert("Agradecemos a sua compra!");
        instance.router.navigate(['/']);
      })
      .catch(function (error) {
        console.log(error);
        if (error.response.status == 0) {
          instance.router.navigate(['/login'])
        }
      });
  }

}