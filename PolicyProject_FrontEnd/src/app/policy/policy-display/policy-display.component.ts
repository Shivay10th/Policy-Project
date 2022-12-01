import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/shared/policy/policy.service';

@Component({
  selector: 'app-policy-display',
  templateUrl: './policy-display.component.html',
  styleUrls: ['./policy-display.component.css']
})
export class PolicyDisplayComponent implements OnInit {

  constructor(public objSrv:PolicyService) { }

  local:any;
  ngOnInit(): void {
    this.objSrv.getPolicyList();
    this.local=localStorage;
  }
  del(PolicyId){
    if(confirm("Are u sure u want to delete this field")){

      this.objSrv.del(PolicyId).subscribe(res=>{
        this.objSrv.getPolicyList();
        alert("Passport Record Deleted");
      },err=>{
        alert("Error"+err)
      })
    }
}

}
