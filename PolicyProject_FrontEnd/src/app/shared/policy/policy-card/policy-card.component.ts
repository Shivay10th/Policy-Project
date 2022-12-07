import { Component, Input, OnInit } from '@angular/core';
import { Policy } from '../policy.model';
import { PolicyService } from '../policy.service';

@Component({
  selector: 'app-policy-card',
  templateUrl: './policy-card.component.html',
  styleUrls: ['./policy-card.component.css']
})
export class PolicyCardComponent implements OnInit {

   constructor(public policySrv:PolicyService) { }
  @Input() p:Policy
  local:{jwt:string,role:string,userId:string}= {jwt:"",role:"customer",userId:""}
  ngOnInit(): void {
    this.local.jwt=localStorage.getItem("jwt");
    this.local.role=localStorage.getItem("role");
    this.local.userId=localStorage.getItem("userId");
  }

    del(PolicyId){
    if(confirm("Are u sure u want to delete this field")){

      this.policySrv.del(PolicyId).subscribe(res=>{
        this.policySrv.getPolicyList();
        console.log(res);
        alert("Policy Record Deleted");
      },err=>{
        alert("Error"+err)
      })
    }
}

}
