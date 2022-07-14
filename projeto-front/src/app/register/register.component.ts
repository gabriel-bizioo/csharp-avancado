import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  titlePage="Register"

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  

  saveForNextPage(){
    let name = document.getElementById("nome_cad") as HTMLInputElement;
    let login = document.getElementById("login_cad") as HTMLInputElement;
    let Document = document.getElementById("Document") as HTMLInputElement;
    let date_of_birth = document.getElementById("Birthday") as HTMLInputElement;
    let phone = document.getElementById("number") as HTMLInputElement;
    let email = document.getElementById("email_cad") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;
    let confirm = document.getElementById("confirmPassword") as HTMLInputElement;

    localStorage.setItem('name', name.value);
    localStorage.setItem('login', login.value);
    localStorage.setItem('Document', Document.value);
    localStorage.setItem('date_of_birth', date_of_birth.value);
    localStorage.setItem('phone', phone.value);
    localStorage.setItem('email', email.value);
    localStorage.setItem('passwd', passwd.value);
    localStorage.setItem('confirm', confirm.value);

    window.alert(localStorage.getItem('name'));

    this.router.navigate(['/address-register']);
  }
}
