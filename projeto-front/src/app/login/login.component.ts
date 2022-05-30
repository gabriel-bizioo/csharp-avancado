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
  constructor(private router: Router) { }

  loginClient(){
    let user = document.getElementById("nome") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;

    var data = JSON.stringify(
    {
      "login": user.value,
      "passwd": passwd.value
    })

    console.log(data)

    var config = {
      method: 'post',
      url: 'http://localhost:5118/client/api',
      headers: {
        'Content-type':'application/json'
      },
      data: data
    };

  let instance = this;
  
    axios(config)
  .then(function (response:any) {
    localStorage.setItem('authToken', response.data);
    instance.router.navigate(['/']);
  })
  .catch(function (error:any) {
    console.log(error);
  });
  }

  ngOnInit(): void {  }

}

