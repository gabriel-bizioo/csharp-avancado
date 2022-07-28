import { Component, Input, OnInit } from '@angular/core';


@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  @Input() titulo=""
  
 isClient = false;
 isOwner = false;
  ngOnInit(): void {   
  this.verifica();
  }

  verifica(){
    if(localStorage.getItem('user') == 'client'){
      this.isClient = true;
      this.isOwner = false;
    }
      else if (localStorage.getItem('user') == 'owner'){
        this.isClient = false;
        this.isOwner = true;
      }
    else{
      this.isClient = false;
      this.isOwner = false;
    }
  }
}
