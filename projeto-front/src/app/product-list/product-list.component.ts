import { Component, OnInit } from '@angular/core';
import { products } from '../products';

@Component({
  selector: 'app-products-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products = products;
  
  constructor() { }

  ngOnInit(): void 
  {
    var config = {
      method: 'get',
      url: 'http://localhost:5118/product/getAll',
      headers: { }
    };
    
    // axios(config)
    // .then(function (response) {
    //   console.log(JSON.stringify(response.data));
    // })
    // .catch(function (error) {
    //   console.log(error);
    // });
      
  }


}