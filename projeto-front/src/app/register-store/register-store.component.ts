import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Store } from '../store';

@Component({
  selector: 'app-register-store',
  templateUrl: './register-store.component.html',
  styleUrls: ['./register-store.component.css']
})
export class RegisterStoreComponent implements OnInit {
  titlePage="Store Register";
  constructor() { }

  ngOnInit(): void {
  }

  registerStore()
  {
    let token = localStorage.getItem('authToken');

    let name = (document.getElementById('name') as HTMLInputElement).value;
    let cnpj = (document.getElementById('cnpj') as HTMLInputElement).value;
    
    let email = localStorage.getItem('email');

    var data = JSON.stringify({
      "name": name,
      "CNPJ": cnpj,

      "owner": {
        "email": email
      }
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5118/store/register',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      data: data
    };

    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        window.alert("Cadastrado");
      })
      .catch(function (error) {
        console.log(error);
        window.alert("Bostil falhou");
      });
  }

}
