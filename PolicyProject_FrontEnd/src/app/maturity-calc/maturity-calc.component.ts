import { Component, OnInit } from '@angular/core';
import { Policy } from '../shared/policy/policy.model';
import { PolicyService } from '../shared/policy/policy.service';

@Component({
  selector: 'app-maturity-calc',
  templateUrl: './maturity-calc.component.html',
  styleUrls: ['./maturity-calc.component.css']
})
export class MaturityCalcComponent implements OnInit {

  constructor(public policyService:PolicyService) { }

  policyList:Policy[]
  selectedPolicy :Policy

  startDate:Date;
  durationInYr:number;
  intitalDepo:number;
  termsPerYr:number;
  termAmount:number;
  endDate:Date;

  maturityAmount:number;


  id :number
  ngOnInit(): void {
    this.policyService.getPolicyLists().subscribe(res=>{
      this.policyList = res["Data"] as Policy[];
      console.log(this.selectedPolicy);
      
    });
  }
  
  calcMaturityAmount(){
    this.maturityAmount = this.intitalDepo  + 2*(this.durationInYr+this.termsPerYr+this.termAmount) * (this.selectedPolicy.Interest/100);
    let sdate = new Date(this.startDate);
    let year = sdate.getFullYear()+this.durationInYr;
    this.endDate = new Date(year,sdate.getMonth(),sdate.getDay());
  }

  changeHandle(){
      this.selectedPolicy=this.policyList.filter(p=>p.PolicyId==this.id)[0] as Policy;

  }

}
