import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {  Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(public objSrv:AuthService,private route:Router) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form!=null){
      form.form.reset();
    }else{
      this.objSrv.cred={Email:"",Password:""};
    }
  }
  login(form:NgForm){
    this.objSrv.login().subscribe(res=>{
      this.resetForm(form)
      
      localStorage.setItem("jwt",res["Data"])
      let tokenInfo = JSON.parse(atob(localStorage.jwt.split('.')[1]));
      localStorage.setItem("role",tokenInfo["role"]);
      localStorage.setItem("userId",tokenInfo["nameid"]);
      
      this.route.navigateByUrl("user/profile");
    },err=>{
      console.log(err);
      
    }) 
  }

}
