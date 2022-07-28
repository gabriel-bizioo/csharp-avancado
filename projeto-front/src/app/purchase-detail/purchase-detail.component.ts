import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { ActivatedRoute, Router } from '@angular/router';
import { Purchase } from '../purchase';
import { Product } from '../products';

@Component({
  selector: 'app-purchase-detail',
  templateUrl: './purchase-detail.component.html',
  styleUrls: ['./purchase-detail.component.css']
})
export class PurchaseDetailComponent implements OnInit {

  titlePage="Purchase Detail";
  purchase: Purchase | undefined
  isClient = false;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void 
  {
    let token = localStorage.getItem('authToken')
    const RouteParams = this.route.snapshot.paramMap;
    const purchaseIdfromRoute = Number(RouteParams.get('purchaseID'));
    
    this.verifica();

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
      if (error.response.status == 0) {
        instance.router.navigate(['/login'])
      }
    });
  }

  verifica(){
    if(localStorage.getItem('client') == 'true'){
      this.isClient = true;
    }
    else{
      this.isClient = false;
    }
  }
}
