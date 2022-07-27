import { Component, OnInit } from '@angular/core';
import { Sale } from '../purchase';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  titlePage="Sales";
  
  sales : [Sale] | undefined

  constructor() { }

  ngOnInit(): void {
  }

}
