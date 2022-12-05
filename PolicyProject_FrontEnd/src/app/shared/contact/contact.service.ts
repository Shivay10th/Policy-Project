import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface  Contact {
  PolicyId:number;
    UserName :string;
    Email:string;
    PhoneNumber:string;
    PolicyType:string;
    Message:string;
    
  }
@Injectable({
  providedIn: 'root'
})
export class ContactService {
  constructor(private obj:HttpClient) { }

  public savecontacts(addcontact){
    return this.obj.post("http://localhost:22446/api/Contacts",addcontact,{
      observe:'response',headers:new HttpHeaders({"Content-Type":"application/json"})})
}
}
