import { Injectable } from '@angular/core';
import { AuthLogin } from './auth-login.model';
import {HttpClient} from '@angular/common/http';
import { AuthRegister } from './auth-register.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http:HttpClient) { }


  Host = environment.host;

  readonly apiUrl=`${this.Host}/auth/`
  cred:AuthLogin
  regcred:AuthRegister

  login(){
    return this.http.post(this.apiUrl+"login",this.cred);
    
  }
  register(){    
    return this.http.post(this.apiUrl+"register",this.regcred);
  }
  private isTokenExpired(token: string) {
    if(token===null){
      return true;
    }
  const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
  return expiry * 1000 < Date.now();
}
  isAuthenticated():boolean{
    var token = localStorage.getItem("jwt")?localStorage.getItem("jwt"):null;
    if(this.isTokenExpired(token))
    return false;
    return true;
  }
}
