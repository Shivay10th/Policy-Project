import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Policy } from './policy.model';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  constructor(private http:HttpClient) { }
  Host = environment.host;

  readonly apiUrl=`${this.Host}/policies/`;
  policy:Policy;
  policyList:Policy[]

  
  registerPolicy(){
console.log(this.policy.PolicyType=null)

    return this.http.post(this.apiUrl,this.policy)
  }

  getPolicyById(policyId:number){
    return this.http.get(this.apiUrl+policyId);
  }
  getPolicyByName(policyName:string){
    return this.http.get(this.apiUrl+"search/"+policyName);
  }
  // get List of Policies

  getPolicyList(){
    this.http.get(this.apiUrl,{observe:'response'}).toPromise().then(res=>{this.policyList=res.body["Data"] as Policy[];console.log(this.policyList)})
  }
  getPolicyLists(){
    return this.http.get(this.apiUrl);
  }
  // delete a policy by id
  del(PolicyId){
    return this.http.delete(this.apiUrl+PolicyId);
  }

  updatepolicy(PolicyId,policy){
    policy.policyType=null;
    return this.http.put(this.apiUrl+PolicyId,policy);
  }

}
