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
import { PolicyType } from './shared/policyType/policy-type.model';
import { UserDisplayComponent } from './user/user-display/user-display.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

const routes: Routes = [
  {path:"home",component:HomeComponent},

  {path:"register",component:UserRegisterComponent},
  {path:"user/profile",component:UserDisplayComponent},
  {path:"login",component:UserLoginComponent},
  {path:"policy/register",component:PolicyRegComponent},
  {path:"policy/categories",component:PolicyTypeComponent},
  {path:"policy/search",component:SearchPolicyComponent},
  {path:"policy/maturity_calc",component:MaturityCalcComponent},
  {path:"policies",component:PolicyDisplayComponent},
  {path:"policy/update/:id",component:PolicyUpdateComponent},
  {path:"contact",component:ContactRegComponent},
  {path:"contact/all",component:ContactDisplayComponent},
    {path:"**",pathMatch:"full",redirectTo:"home"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
