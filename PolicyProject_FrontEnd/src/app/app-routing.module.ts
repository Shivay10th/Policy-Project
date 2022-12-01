import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { PolicyDisplayComponent } from './policy/policy-display/policy-display.component';
import { PolicyRegComponent } from './policy/policy-reg/policy-reg.component';
import { PolicyUpdateComponent } from './policy/policy-update/policy-update.component';
import { UserDisplayComponent } from './user/user-display/user-display.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

const routes: Routes = [
  {path:" ",component:HomeComponent},
  {path:"register",component:UserRegisterComponent},
  {path:"user/profile",component:UserDisplayComponent},
  {path:"login",component:UserLoginComponent},
  {path:"policy/register",component:PolicyRegComponent},
  {path:"policies",component:PolicyDisplayComponent},
  {path:"policy/update/:id",component:PolicyUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
