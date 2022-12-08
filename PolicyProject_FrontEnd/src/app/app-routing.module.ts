import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactDisplayComponent } from './contact/contact-display/contact-display.component';
import { ContactRegComponent } from './contact/contact-reg/contact-reg.component';
import { HomeComponent } from './home/home/home.component';
import { MaturityCalcComponent } from './maturity-calc/maturity-calc.component';
import { PolicyDisplayComponent } from './policy/policy-display/policy-display.component';
import { PolicyRegComponent } from './policy/policy-reg/policy-reg.component';
import { PolicyTypeComponent } from './policy/policy-type/policy-type.component';
import { PolicyUpdateComponent } from './policy/policy-update/policy-update.component';
import { SearchPolicyComponent } from './search/search-policy/search-policy.component';
import { AuthGuardGuard } from './shared/auth/auth-guard.guard';
import { PolicyType } from './shared/policyType/policy-type.model';
import { UserDisplayComponent } from './user/user-display/user-display.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

const routes: Routes = [
  {path:"home",component:HomeComponent},

  {path:"register",component:UserRegisterComponent},
  {path:"login",component:UserLoginComponent},
  {path:"user/profile",canActivate:[AuthGuardGuard],component:UserDisplayComponent,data:{expectedRole:localStorage.getItem("role")}},
  {path:"policy/register",canActivate:[AuthGuardGuard],component:PolicyRegComponent,data:{expectedRole:"admin"}},
  {path:"policy/categories",component:PolicyTypeComponent},
  {path:"policy/search",component:SearchPolicyComponent},
  {path:"policy/maturity_calc",component:MaturityCalcComponent},
  {path:"policies",component:PolicyDisplayComponent},
  {path:"policy/update/:id",canActivate:[AuthGuardGuard],component:PolicyUpdateComponent,data:{expectedRole:"admin"}},
  {path:"contact",component:ContactRegComponent},
  {path:"contact/all",canActivate:[AuthGuardGuard],component:ContactDisplayComponent,data:{expectedRole:"admin"}},
    {path:"**",pathMatch:"full",redirectTo:"home"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
