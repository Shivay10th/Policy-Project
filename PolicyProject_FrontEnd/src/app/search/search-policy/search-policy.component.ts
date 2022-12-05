import { Component, OnInit } from '@angular/core';
import { Policy } from '../../shared/policy/policy.model';
import { PolicyService } from '../../shared/policy/policy.service';

@Component({
  selector: 'app-search-policy',
  templateUrl: './search-policy.component.html',
  styleUrls: ['./search-policy.component.css']
})
export class SearchPolicyComponent implements OnInit {

  constructor(private policyService:PolicyService) { }
policyList:Policy[];
  textValue:string

  ngOnInit(): void {
  }

  getPolicyByName(){
    this.policyService.getPolicyByName(this.textValue).subscribe(res=>{
      this.policyList = res["Data"] as Policy[];
    })
  }

}
