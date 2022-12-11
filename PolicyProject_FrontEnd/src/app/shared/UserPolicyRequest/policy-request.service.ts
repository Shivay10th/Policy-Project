import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PolicyRequest } from './policy-request.model';

@Injectable({
  providedIn: 'root'
})
export class PolicyRequestService {
  Host = environment.host;
  constructor(private http:HttpClient) { }


  requestAPolicy(userRequestPolicy:PolicyRequest){
    return this.http.post(`${this.Host}/policyrequest`,userRequestPolicy);
  }
  userPolicyList(userId){
    return this.http.get(`${this.Host}/policyrequest/${userId}`);
  }
  delUserPolicyDetail(userId,policyDId){
    return this.http.delete(`${this.Host}/policyrequest/${userId}/${policyDId}`);
  }
  getPolicyDetails(){
    return this.http.get(`${this.Host}/policyrequest`)
  }
  updatePolicyDetailStatus(policyDetailId,data:any){
    return this.http.put(`${this.Host}/policyrequest/${policyDetailId}`,data)
  }
}
