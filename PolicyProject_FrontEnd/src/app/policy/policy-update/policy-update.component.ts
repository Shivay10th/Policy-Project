import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Policy } from 'src/app/shared/policy/policy.model';
import { PolicyService } from 'src/app/shared/policy/policy.service';

@Component({
  selector: 'app-policy-update',
  templateUrl: './policy-update.component.html',
  styleUrls: ['./policy-update.component.css']
})
export class PolicyUpdateComponent implements OnInit {

  constructor(private route:ActivatedRoute,public policyService:PolicyService) { }
  policy:Policy;
  policyId;number;
  ngOnInit(): void {
    this.policyId=this.route.snapshot.paramMap.get('id')
    this.policyService.getPolicyById(this.policyId).subscribe(res=>{
      console.log(res);
    })
  }

}
