import { Injectable } from '@angular/core';
import { AuthLogin } from './auth-login.model';
import {HttpClient} from '@angular/common/http';
import { AuthRegister } from './auth-register.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  Host = environment.host;
  constructor(private http:HttpClient) { }
  readonly apiUrl=`${this.Host}/auth/`
  cred:AuthLogin
  regcred:AuthRegister
  token:string

  login(){
    return this.http.post(this.apiUrl+"login",this.cred);
    
  }
  register(){
    console.log(this.regcred);
    
    return this.http.post(this.apiUrl+"register",this.regcred);
  }
}
