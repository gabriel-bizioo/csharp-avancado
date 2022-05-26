import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  titlePage="Login";
  constructor() { }

  loginClient(){
    let user = document.getElementById("nome") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;

    var data = JSON.stringify(
      {
      "login": user.value,
      "passwd": passwd.value
    }
    )

    console.log(data)

    var config = {
      method: 'post',
      url: 'http://localhost:5118/client/api',
      headers: {
        'Content-type':'application/json'
      },
      data: data
    };

    axios(config)
  .then(function (response:any) {
    console.log(JSON.stringify(response.data));
  })
  .catch(function (error:any) {
    console.log(error);
  });
  }

  ngOnInit(): void {
  }

}

