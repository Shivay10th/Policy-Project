import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Policy } from './policy.model';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  constructor(private http:HttpClient) { }
  readonly apiUrl="http://localhost:2459/api/policies/";
  policy:Policy;
  policyList:Policy[]

  _authHeader(){
    let headers = new HttpHeaders();
    return headers.set("Authorization","Bearer "+localStorage.getItem("jwt"));
  }
  
  registerPolicy(){


    return this.http.post(this.apiUrl,this.policy,{headers:this._authHeader()})
  }

  getPolicyById(policyId:number){
    return this.http.get(this.apiUrl+policyId,{headers:this._authHeader()});
  }
  // get List of Policies

  getPolicyList(){
    this.http.get(this.apiUrl,{observe:'response'}).toPromise().then(res=>{this.policyList=res.body["Data"] as Policy[]})
  }
  // delete a policy by id
  del(PolicyId){
    return this.http.delete(this.apiUrl+PolicyId,{headers:this._authHeader()});
  }

  updatepolicy(PolicyId){
    return this.http.delete(this.apiUrl+PolicyId,{headers:this._authHeader()});
  }

}
