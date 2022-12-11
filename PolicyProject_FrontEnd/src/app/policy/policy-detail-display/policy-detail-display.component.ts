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

updatePolicyDetailStatus(policyDetailId){
this.policyDetailSrv.updatePolicyDetailStatus(policyDetailId,{Status:this.option}).subscribe(res=>{
  alert(`Policy Request ${this.option}` );

},err=>alert("Something Went Wrong"))
}

  ngOnInit(): void {
    this.local=localStorage;
    this.policyDetailSrv.getPolicyDetails().subscribe(res=>{
      this.policyDetails=res["Data"] as PolicyRequest[];
    })
  }

}
