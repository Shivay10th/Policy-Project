import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PolicyType } from './policy-type.model';

@Injectable({
  providedIn: 'root'
})
export class PolicyTypeService {

  constructor(private http:HttpClient) { }
  readonly apiUrl ="http://localhost:2459/api/policy/category/";
  policyTypeList:PolicyType[]
  getPolicyTypes(){

    this.http.get(this.apiUrl,{observe:'response'}).toPromise().then(res=>{this.policyTypeList=res.body["Data"] as PolicyType[]})
  }
}
