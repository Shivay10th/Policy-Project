import { Component, OnInit } from '@angular/core';
import { PolicyRequest } from 'src/app/shared/UserPolicyRequest/policy-request.model';
import { PolicyRequestService } from 'src/app/shared/UserPolicyRequest/policy-request.service';

@Component({
  selector: 'app-policy-detail-display',
  templateUrl: './policy-detail-display.component.html',
  styleUrls: ['./policy-detail-display.component.css']
})
export class PolicyDetailDisplayComponent implements OnInit {

  constructor(public policyDetailSrv:PolicyRequestService) { }
policyDetails:PolicyRequest[];
local:any;
option:any;
handleOnChange(){
console.log(this.option)
}

updatePolicyDetailStatus(policyDetailId,Status){
  
  if(Status){
this.policyDetailSrv.updatePolicyDetailStatus(policyDetailId,{Status:Status}).subscribe(res=>{
  alert(`Policy Request updated` );
  window.location.reload();

},err=>alert("Something Went Wrong"))
  }else{
    alert("Please Select Valid Option!!")
  }
}

  ngOnInit(): void {
    this.local=localStorage;
    this.policyDetailSrv.getPolicyDetails().subscribe(res=>{
      this.policyDetails=res["Data"] as PolicyRequest[];
      this.option=this.policyDetails["Status"];
    })
  }

}
