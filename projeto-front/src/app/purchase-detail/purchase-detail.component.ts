import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { ActivatedRoute } from '@angular/router';
import { Purchase } from '../purchase';

@Component({
  selector: 'app-purchase-detail',
  templateUrl: './purchase-detail.component.html',
  styleUrls: ['./purchase-detail.component.css']
})
export class PurchaseDetailComponent implements OnInit {

  titlePage="Purchase Detail";
  purchase: Purchase | undefined
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void 
  {
    let token = localStorage.getItem('authToken')
    const RouteParams = this.route.snapshot.paramMap;
    const purchaseIdfromRoute = Number(RouteParams.get('purchaseID'));

    var config = 
    {
      method: 'get',
      url: 'http://localhost:5118/purchase/getpurchase/' + purchaseIdfromRoute,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    let instance = this;
    axios(config)
    .then(function (response) {
     instance.purchase = response.data;
     console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });
  }
}
