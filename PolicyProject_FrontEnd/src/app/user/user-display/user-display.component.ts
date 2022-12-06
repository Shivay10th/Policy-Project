import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/shared/user/user.model';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-user-display',
  templateUrl: './user-display.component.html',
  styleUrls: ['./user-display.component.css']
})
export class UserDisplayComponent implements OnInit {

  constructor(public objSrv:UserService) { }
local:any
  status:{message:string,error:boolean}={message:"",error:true};

  ngOnInit(): void {
    this.getProfile();
    this.status=history.state.status;
    this.local=localStorage; 
  }

  userProfile:User
  getProfile(){
    this.objSrv.getUserById().subscribe(res=>{
      this.userProfile=res as User
      
    })
  }

}
