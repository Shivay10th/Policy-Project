import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Policy } from '../shared/policy/policy.model';
import { PolicyService } from '../shared/policy/policy.service';
import { PolicyRequest } from '../shared/UserPolicyRequest/policy-request.model';
import { PolicyRequestService } from '../shared/UserPolicyRequest/policy-request.service';

@Component({
  selector: 'app-maturity-calc',
  templateUrl: './maturity-calc.component.html',
  styleUrls: ['./maturity-calc.component.css']
})
export class MaturityCalcComponent implements OnInit {

  constructor(public policyService:PolicyService,private policyRequestSrv:PolicyRequestService,private router :Router) { }

  policyList:Policy[]
  selectedPolicy :Policy = new Policy();

  startDate:Date;
  durationInYr:number;
  intitalDepo:number;
  termsPerYr:number;
  termAmount:number;
  endDate:Date;

  maturityAmount:number;
  policyRequest:PolicyRequest = new PolicyRequest();

  id :number
  ngOnInit(): void {
    this.policyService.getPolicyList().subscribe(res=>{
      this.policyList = res["Data"] as Policy[];
      console.log(this.selectedPolicy);
      
    });
  }
  buyOption:boolean=false;


  calcMaturityAmount(){
    this.policyRequest.Duration=this.durationInYr;
    this.policyRequest.InitialDeposite=this.intitalDepo;
    this.policyRequest.StartDate=this.startDate;
    this.policyRequest.TermsAmount=this.termAmount;
    this.policyRequest.TermsPerYear=this.termsPerYr;
    this.policyRequest.PolicyId=this.selectedPolicy.PolicyId;
    this.policyRequest.UserId=localStorage.getItem("userId");
    this.buyOption=true;
    this.maturityAmount = this.intitalDepo  + 2*(this.durationInYr+this.termsPerYr+this.termAmount) * (this.selectedPolicy.Interest/100);
    let sdate = new Date(this.startDate);
    let year = sdate.getFullYear()+this.durationInYr;
    this.endDate = new Date(year,sdate.getMonth(),sdate.getDay());
  }

  changeHandle(){
      this.selectedPolicy=this.policyList.filter(p=>p.PolicyId==this.id)[0] as Policy;

  }
  buyPolicy(){
    if(confirm('Do u Want to Buy this Policy')){
      this.policyRequestSrv.requestAPolicy(this.policyRequest).subscribe(res=>{
        alert("Policy Bought!!")
        console.log(res);
        this.router.navigate(["/user/policy/all"])
        
      });
    }
  }

}
