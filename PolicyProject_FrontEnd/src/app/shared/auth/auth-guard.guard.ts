import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardGuard implements CanActivate {
  /**
   *
   */
  constructor(private authservice:AuthService,private router:Router) {
    
  }
  canActivate(
    route: ActivatedRouteSnapshot,
   ){
    var token = localStorage.getItem("jwt");
    var role = JSON.parse(atob(token.split(".")[1]))["role"];
      if (this.authservice.isAuthenticated && (route.data.expectedRole==="any"||route.data.expectedRole===role)) {
        return true;
      } else {
        this.router.navigate(["login"]);
        return false;
        
      }
  }
  
}
