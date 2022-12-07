import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PolicyType } from './policy-type.model';

@Injectable({
  providedIn: 'root'
})
export class PolicyTypeService {
  Host = environment.host;
  constructor(private http:HttpClient) { }
  readonly apiUrl =`${this.Host}/policy/category/`;
  policyTypeList:PolicyType[]

    _authHeader(){
    let headers = new HttpHeaders();
    return headers.set("Authorization","Bearer "+localStorage.getItem("jwt"));
  }
  getPolicyTypes(){

    this.http.get(this.apiUrl,{observe:'response'}).toPromise().then(res=>{this.policyTypeList=res.body["Data"] as PolicyType[]})
  }
  postPolicyType(policyType:PolicyType){
    return this.http.post(this.apiUrl,policyType,{headers:this._authHeader()})
  }
  deletePolicyType(id){
    return this.http.delete(this.apiUrl+id,{headers:this._authHeader()});
  }
}
