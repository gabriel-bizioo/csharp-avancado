import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import axios from 'axios';
import { Purchase } from '../purchase';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  titlePage="Purchases";
  purchases : [Purchase] | undefined

  constructor() { }

  ngOnInit(): void 
  {
    var config = 
    {
      method: 'get',
      url: 'http://localhost:5118/purchase/getclient/' + localStorage.getItem("email"),
      headers: { }
    };

    let instance = this
    axios(config)
    .then(function (response) {
      instance.purchases = response.data;
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });

  }

}
