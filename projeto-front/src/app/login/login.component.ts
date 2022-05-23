import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  titlePage = "Site";
  constructor() { }

  ngOnInit(): void {
  }

  loginClient(){
    let user = document.getElementById("nome_login")
    let passwd = document.getElementById("password")

    var data = JSON.stringify({
      "login": user,
      "passwd": passwd
    })

    console.log(user, passwd)

    var config = {
      method: 'post',
      url: 'http://localhost:5118/client/login',
      headers: {
        'Content-type':'application/json'
      },
      data: data
    };

    axios(config)
  }
}

