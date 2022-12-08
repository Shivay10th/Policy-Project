import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorSrvService implements HttpInterceptor {

  constructor() { 

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let currentUser = {jwt:""};
    if(localStorage.getItem("jwt")!==null){
      currentUser.jwt=localStorage.getItem('jwt');
    }
      req=req.clone({
        setHeaders:{
          Authorization:`Bearer ${currentUser.jwt}`
        }
      })
      return next.handle(req);
  }
}
