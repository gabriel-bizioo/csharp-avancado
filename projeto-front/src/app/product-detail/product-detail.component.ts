import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Product, products} from '../products';

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
    this.product = products.find(product => product.id===productIdfromRoute);
  }

}
