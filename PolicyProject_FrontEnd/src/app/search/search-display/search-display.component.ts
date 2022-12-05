import { Component, OnInit,Input } from '@angular/core';
import { Policy } from '../../shared/policy/policy.model';
import { PolicyService } from '../../shared/policy/policy.service';

@Component({
  selector: 'app-search-display',
  templateUrl: './search-display.component.html',
  styleUrls: ['./search-display.component.css']
})
export class SearchDisplayComponent implements OnInit {

  constructor(private policyService:PolicyService) { }

  @Input() policyList:Policy[]
  local:any
onclick(){
  console.log(this.policyList)
}
  ngOnInit(): void {
    this.local=localStorage;

  }
  del(PolicyId){
    if(confirm("Are u sure u want to delete this field")){

      this.policyService.del(PolicyId).subscribe(res=>{
        this.policyService.getPolicyList();
        console.log(res);
        alert("Passport Record Deleted");
      },err=>{
        alert("Error"+err)
      })
    }
}
}
