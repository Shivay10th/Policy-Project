import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PolicyType } from 'src/app/shared/policyType/policy-type.model';
import { PolicyTypeService } from 'src/app/shared/policyType/policy-type.service';

@Component({
  selector: 'app-policy-type',
  templateUrl: './policy-type.component.html',
  styleUrls: ['./policy-type.component.css']
})
export class PolicyTypeComponent implements OnInit {

  constructor(public objPolicyType:PolicyTypeService ) { }
local:any
policyType:PolicyType={Name:"",Id:""};
  ngOnInit(): void {
    this.objPolicyType.getPolicyTypes();
    this.local=localStorage;


  }

  refresh(): void {
    window.location.reload();
}

del(id){
this.objPolicyType.deletePolicyType(id).subscribe(res=>{
  console.log(res);
  this.refresh();
},err=>{
  console.log(err);
})
}
registerPolicyType(policyType:PolicyType){

  this.policyType.Id=0;
this.objPolicyType.postPolicyType(policyType).subscribe(res=>{
  console.log(res);
  this.refresh();
},err=>{
  console.log(err);
});
}
}
