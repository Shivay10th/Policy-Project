import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, EMPTY } from 'rxjs';
import { map,catchError } from 'rxjs/operators';
import { Policy } from './policy.model';
import { PolicyService } from './policy.service';

@Injectable({
  providedIn: 'root'
})
export class PolicyResolver implements Resolve<any> {
  constructor(private router:Router,private policyService:PolicyService){}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Policy[]> {
   return this.policyService.getPolicyList().pipe(
    
      map(res=>res["Data"] as Policy[]),catchError(()=>{
        this.router.navigate([""]);
        return EMPTY;
      })
    );
   
  }
}
