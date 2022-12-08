import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class ContactService {
  Host = environment.host;
  readonly apiUrl=`${this.Host}/Contacts`

  constructor(private obj:HttpClient) { }

  public savecontacts(addcontact){
    return this.obj.post(this.apiUrl,addcontact,{
      observe:'response',headers:new HttpHeaders({"Content-Type":"application/json"})})
}
  getAllContacts(){
    return this.obj.get(this.apiUrl);
  }
}
