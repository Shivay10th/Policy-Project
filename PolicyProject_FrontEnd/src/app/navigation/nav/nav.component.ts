import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private route:Router) { }
  local:any;
  ngOnInit(): void {
    this.local=localStorage
  }

  logOut(){
    localStorage.clear();
    this.route.navigate(['/login'],{state:{status:{message:"Logout success!!",error:true}}})
  }
}
