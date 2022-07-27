import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  titlePage="Login";
  isClient = true;
  constructor(private router: Router) { }

  change(isClient: boolean) {
    this.isClient = isClient;
    console.log(this.isClient);
  }

  loginUser(){
    let user = document.getElementById("nome") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;

    let instance = this;

    let path : string;

    var data = JSON.stringify(
    {
      "login": user.value,
      "passwd": passwd.value
    })

    console.log(data)

    if(instance.isClient){
      path = 'http://localhost:5118/client/api';
      localStorage.setItem('client', "true");
    }
    else{
      path = 'http://localhost:5118/owner/api';
    }

    var config = {
      method: 'post',
      url: path,
      headers: {
        'Content-type':'application/json'
      },
      data: data
    };

  
  axios(config)
  .then(function (response:any) {
    localStorage.setItem('authToken', response.data['token']);
    localStorage.setItem('email', response.data['email']);
    instance.router.navigate(['/']);
  })
  .catch(function (error:any) {
    console.log(error);
    localStorage.clear();
  });
  }

  ngOnInit(): void {  }

}


