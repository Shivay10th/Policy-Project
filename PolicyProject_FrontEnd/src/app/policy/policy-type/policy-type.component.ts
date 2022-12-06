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
del(id){

}
registerPolicyType(form:NgForm){

}
}
