import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PolicyTypeService } from 'src/app/shared/policyType/policy-type.service';
import { Policy } from 'src/app/shared/policy/policy.model';
import { PolicyService } from 'src/app/shared/policy/policy.service';

@Component({
  selector: 'app-policy-update',
  templateUrl: './policy-update.component.html',
  styleUrls: ['./policy-update.component.css']
})
export class PolicyUpdateComponent implements OnInit {

  policy:Policy;
  policyId;

  constructor(private activatedRoute:ActivatedRoute,private route:Router,public policyService:PolicyService,public objPolicyType:PolicyTypeService) { }

  ngOnInit(): void {
    this.objPolicyType.getPolicyTypes();
    this.policyId=this.activatedRoute.snapshot.paramMap.get('id')
    this.policyService.getPolicyById(this.policyId).subscribe(res=>{
      this.policy= res["Data"] as Policy      
    })
  }
  updatePolicy(){
    this.policyService.updatepolicy(this.policyId,this.policy).subscribe(res=>{
      this.route.navigateByUrl('/policies');
    },err=>{
      console.log(err);
    })
  }
  
}
