import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PolicyRequest } from 'src/app/shared/UserPolicyRequest/policy-request.model';
import { PolicyRequestService } from 'src/app/shared/UserPolicyRequest/policy-request.service';

@Component({
  selector: 'app-user-policy-display',
  templateUrl: './user-policy-display.component.html',
  styleUrls: ['./user-policy-display.component.css']
})
export class UserPolicyDisplayComponent implements OnInit {

  constructor(public userPolicyRequestSrv:PolicyRequestService,private route:Router) { }

  userPolicyRequestList:PolicyRequest[];
  local:any;

  ngOnInit(): void {
    this.local=localStorage
    let id = localStorage.getItem("userId");
    this.userPolicyRequestSrv.userPolicyList(id).subscribe(res=>{
      console.log(res);
      this.userPolicyRequestList=res["Data"];
      
    })
  }

  del(id){
    confirm("Are u sure!!")
    this.userPolicyRequestSrv.delUserPolicyDetail(this.local["userId"],id).subscribe(res=>{
      console.log("Policy Deleted!!");
      window.location.reload();
      console.log(res);
    })
  }

}
