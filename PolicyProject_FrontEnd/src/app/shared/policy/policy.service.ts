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

  registerPolicy(){
    let headers = new HttpHeaders();
    headers=headers.set("Authorization","Bearer "+localStorage.getItem("jwt"));

    return this.http.post(this.apiUrl,this.policy,{headers:headers})
  }

}
