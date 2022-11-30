import { Injectable } from '@angular/core';
import { AuthLogin } from './auth-login.model';
import {HttpClient} from '@angular/common/http';
import { AuthRegister } from './auth-register.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }
  readonly apiUrl="http://localhost:2459/api/auth/"
  cred:AuthLogin
  regcred:AuthRegister
  token:string

  login(){
    return this.http.post(this.apiUrl+"login",this.cred);
    // console.log(data);
    
  }
  register(){
    console.log(this.regcred);
    
    return this.http.post(this.apiUrl+"register",this.regcred);
  }
}
