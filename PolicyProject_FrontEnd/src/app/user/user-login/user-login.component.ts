import { Component, OnInit,ChangeDetectorRef  } from '@angular/core';
import { NgForm } from '@angular/forms';
import {  Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { Status } from 'src/app/shared/message/status.model';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})

export class UserLoginComponent implements OnInit {

  constructor(public objSrv:AuthService,private route:Router) {
    this.status= new Status();
   }

  ngOnInit(): void {

    this.resetForm();
    this.status=history.state.status!== undefined? history.state.status as Status :new Status();
  }

  resetForm(form?:NgForm){
    if(form!=null){
      form.form.reset();
    }else{
      this.objSrv.cred={Email:"",Password:""};
    }
  }
  status:Status;;
  login(form:NgForm){
    this.objSrv.login().subscribe(res=>{
      console.log(res);
      this.resetForm(form)
      this.status.error=false;
      this.status.message="Login successful";
      localStorage.setItem("jwt",res["Data"])
      let tokenInfo = JSON.parse(atob(localStorage.jwt.split('.')[1]));
      localStorage.setItem("role",tokenInfo["role"]);
      localStorage.setItem("userId",tokenInfo["nameid"]);
      
      this.route.navigate(["user/profile"],{state:{status:this.status}});
    },err=>{
      this.status.error=true;
      this.status.message=err.error["Message"];
      
    }) 
  }

}
