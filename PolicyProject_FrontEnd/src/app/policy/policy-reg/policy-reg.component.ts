import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PolicyType } from 'src/app/shared/policyType/policy-type.model';
import { PolicyTypeService } from 'src/app/shared/policyType/policy-type.service';
import { PolicyService } from 'src/app/shared/policy/policy.service';

@Component({
  selector: 'app-policy-reg',
  templateUrl: './policy-reg.component.html',
  styleUrls: ['./policy-reg.component.css']
})
export class PolicyRegComponent implements OnInit {

  constructor(public objSrv:PolicyService,private route:Router,public objPolicyType:PolicyTypeService) { }
  ngOnInit(): void {
    this.resetForm();
    this.objPolicyType.getPolicyTypes();
  }

  resetForm(form?:NgForm,){
    if(form!=null){
      form.form.reset();
    }else{
      this.objSrv.policy={PolicyId:0,PolicyName:"",StartDate:"",Duration:"",CompanyName:"",
      InitialDeposite:"",UserType:"",TermsPerYear:"",TermsAmount:"",Interest:"",PolicyTypeId:"",PolicyType:{}};
    }
  }

  registerPolicy(form:NgForm){
    this.objSrv.registerPolicy().subscribe(res=>{
      this.resetForm(form)

        console.log(res);
        this.route.navigateByUrl('/policies');
    },err=>{
      console.log(err);
      
      alert("error")
    })
  }


}
