import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import axios from 'axios';
import { wishList } from '../wishList';


@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.css']
})
export class WishListComponent implements OnInit {
  titlePage="Products";
  wishLists: [wishList] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
