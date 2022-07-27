import { Component, Input, OnInit } from '@angular/core';


@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  @Input() titulo=""
  
 isClient = false;
  
  ngOnInit(): void {   
  this.verifica();
  }

  verifica(){
    if(localStorage.getItem('client') == 'true'){
      this.isClient = true;
    }
    else{
      this.isClient = false;
    }
  }
}
