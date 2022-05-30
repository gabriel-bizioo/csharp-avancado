import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  titlePage="Register"
  constructor() { }

  ngOnInit(): void {
  }

  registerAccount(){
   
    let name = document.getElementById("nome_cad") as HTMLInputElement;
    let login = document.getElementById("login_cad") as HTMLInputElement;
    let Document = document.getElementById("Document") as HTMLInputElement;
    let date_of_birth = document.getElementById("Birthday") as HTMLInputElement;
    let phone = document.getElementById("number") as HTMLInputElement;
    let email = document.getElementById("email_cad") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;
    let confirm = document.getElementById("confirmPassword") as HTMLInputElement;

    if(passwd.value == confirm.value)
    {
      alert("aqui");
      var data = JSON.stringify({
        "name": name.value,
        "date_of_birth": date_of_birth.value,
        "document": Document.value,
        "email": email.value,
        "phone": phone.value,
        "login": login.value,
        "passwd": passwd.value,
        "client_address": {
          "street": "rua",
          "city": "cidade",
          "state": "estado",
          "country": "pais",
          "postal_code": "00000000"
        }
      }); 
      var config = {
        method: 'post',
        url: 'http://localhost:5118/client/register',
        headers: { 
          'Content-Type': 'application/json'
        },
        data : data
      };
      
      axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
      })
      .catch(function (error) {
        console.log(error);
      });
    }

  }
}
