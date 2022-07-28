import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import axios from 'axios';
import { Purchase } from '../purchase';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  titlePage="Sales";
  
  sales : [Purchase] | undefined

  constructor(private router: Router) { }

  ngOnInit(): void {
    let token = localStorage.getItem('authToken');

    var config =
    {
      method: 'get',
      url: 'http://localhost:5118/purchase/getowner/' + localStorage.getItem("email"),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    let instance = this
      axios(config)
      .then(function (response) {
        instance.sales = response.data;
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
