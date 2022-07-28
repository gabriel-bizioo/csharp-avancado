import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import { ActivatedRoute, Router } from '@angular/router';
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
  isClient = false;

  constructor( private router: Router) { }

  ngOnInit(): void 
  {
    let token = localStorage.getItem('authToken');  

    var config = 
    {
      method: 'get',
      url: 'http://localhost:5118/purchase/getclient/' + localStorage.getItem("email"),
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    let instance = this
    axios(config)
    .then(function (response) {
      instance.purchases = response.data;
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
      if (error.response.status == 0) {
        instance.router.navigate(['/login'])
      }
    });
  }
}
