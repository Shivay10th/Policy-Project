import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Policy } from 'src/app/shared/policy/policy.model';
import { PolicyService } from 'src/app/shared/policy/policy.service';

@Component({
  selector: 'app-policy-display',
  templateUrl: './policy-display.component.html',
  styleUrls: ['./policy-display.component.css']
})
export class PolicyDisplayComponent implements OnInit {

  constructor(public objSrv:PolicyService,private route:Router) { }

  local:any;
  policyList:Policy[]
  ngOnInit(): void {
    this.objSrv.getPolicyList().subscribe(res=>{
      this.policyList=res["Data"] as Policy[];
    });
    this.local=localStorage;
  }
  del(PolicyId){
    if(confirm("Are u sure u want to delete this field")){

      this.objSrv.del(PolicyId).subscribe(res=>{
        this.objSrv.getPolicyList();
        console.log(res);
        alert("Passport Record Deleted");
      },err=>{
        alert("Error"+err)
      })
    }
}



}
