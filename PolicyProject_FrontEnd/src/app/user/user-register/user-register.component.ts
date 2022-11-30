import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth/auth.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  constructor(public objSrv:AuthService,private route:Router) { }

  ngOnInit(): void {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form!=null){
      form.form.reset();
    }else{
      this.objSrv.regcred={FirstName:"",LastName:"",DOB:"",ContactNo:"",Email:"",Salary:"",Pan:"",EmployerName:"",Password:""};
    }
  }

  register(form:NgForm){
    this.objSrv.register().subscribe(res=>{
      this.resetForm(form)

        console.log(res);
        this.route.navigateByUrl('/login');
    },err=>{
      console.log(err);
      
      alert("error")
    })
  }
}
