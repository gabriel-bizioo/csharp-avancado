import { Component, OnInit } from '@angular/core';
import { HostListener } from "@angular/core";
import { Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-register-address',
  templateUrl: './register-address.component.html',
  styleUrls: ['./register-address.component.css']
})
export class RegisterAddressComponent implements OnInit {
  titlePage="Register"

  isClient = true;

  constructor(private router: Router) { }

  @HostListener("window:beforeunload", ["$event"])
  clearLocalStorage(event : any) {
    localStorage.clear();
  }

  ngOnInit(): void {
  }

  change(isClient: boolean) {
    this.isClient = isClient;
    console.log(this.isClient);
  }



  registerAccount() {

    var street = document.getElementById("Street") as HTMLInputElement;
    var state = document.getElementById("State") as HTMLInputElement;
    var city = document.getElementById("City") as HTMLInputElement;
    var country = document.getElementById("Country") as HTMLInputElement;
    var postal_code = document.getElementById("Postal") as HTMLInputElement;

    if (localStorage.getItem('passwd') == localStorage.getItem('confirm')) {

      let instance = this;

      let path : string;

      
      
      var data = JSON.stringify({
        "name": localStorage.getItem("name"),
        "date_of_birth": localStorage.getItem('date_of_birth'),
        "document": localStorage.getItem('Document'),
        "email": localStorage.getItem('email'),
        "phone": localStorage.getItem('phone'),
        "login": localStorage.getItem('login'),
        "passwd": localStorage.getItem('passwd'),
        "address": {
          "street": street.value,
          "city": city.value,
          "state": state.value,
          "country": country.value,
          "postal_code": postal_code.value
        }
      });

      if (instance.isClient) {

        var config = {
          method: 'post',
          url: 'http://localhost:5118/client/register',
          headers: {
            'Content-Type': 'application/json'
          },
          data: data
        }
      }
      else {

        var config = {
          method: 'post',
          url: 'http://localhost:5118/owner/register',
          headers: {
            'Content-Type': 'application/json'
          },
          data: data        
      }

      };

      axios(config)
        .then(function (response) {
          console.log(JSON.stringify(response.data));
          window.alert("Account registered successfully");
          localStorage.clear();
          localStorage.setItem('email', response.data['email']);
          instance.router.navigate(['/']);
        })
        .catch(function (error) {
          console.log(error);
          window.alert("Problem registering account");
          localStorage.clear;
          instance.router.navigate(['/register']);
        });
    }
  }






    // registerAddress(){
    
  //   let street = document.getElementById("Street") as HTMLInputElement;
  //   let state = document.getElementById("State") as HTMLInputElement;
  //   let city = document.getElementById("City") as HTMLInputElement;
  //   let country = document.getElementById("Country") as HTMLInputElement;
  //   let postal_code = document.getElementById("Postal") as HTMLInputElement;

  //   var data = JSON.stringify({
  //     "street": street.value,
  //     "state": state.value,
  //     "city": city.value,
  //     "country": country.value,
  //     "postal_code": postal_code.value
  //   });

  //   var config = {
  //     method : 'post',
  //     url: 'http://localhost:5118/address/register/' + localStorage.getItem('email'),
  //     headers: { 
  //       'Content-Type': 'application/json'
  //     },
  //     data : data
  //   }
    
  //   axios(config)
  //   .then(function (response) {
  //     console.log(JSON.stringify(response.data));
  //     window.alert("Address registered successfully");
  //   })
  //   .catch(function (error) {
  //     console.log(error);
  //     window.alert("Problem registering address");
  //   });
  // }
}
