import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-register-address',
  templateUrl: './register-address.component.html',
  styleUrls: ['./register-address.component.css']
})
export class RegisterAddressComponent implements OnInit {
  titlePage="Register"
  constructor() { }

  ngOnInit(): void {
  }

  registerAddress(){
    
    let street = document.getElementById("Street") as HTMLInputElement;
    let state = document.getElementById("State") as HTMLInputElement;
    let city = document.getElementById("City") as HTMLInputElement;
    let country = document.getElementById("Country") as HTMLInputElement;
    let postal_code = document.getElementById("Postal") as HTMLInputElement;

    var data = JSON.stringify({
      "street": street.value,
      "state": state.value,
      "city": city.value,
      "country": country.value,
      "postal_code": postal_code.value
    });

    var config = {
      method : 'post',
      url: 'http://localhost:5118/address/register',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    }
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });

  }
}
