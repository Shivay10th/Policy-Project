import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor() { }
  local:any;
  ngOnInit(): void {
    this.local=localStorage
  }

  logOut(){
    localStorage.clear();
  }
}
