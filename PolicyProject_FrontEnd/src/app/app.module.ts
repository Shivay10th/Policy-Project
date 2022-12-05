import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserDisplayComponent } from './user/user-display/user-display.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { NavComponent } from './navigation/nav/nav.component';
import { HomeComponent } from './home/home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PolicyRegComponent } from './policy/policy-reg/policy-reg.component';
import { PolicyDisplayComponent } from './policy/policy-display/policy-display.component';
import { FooterComponent } from './footer/footer/footer.component';
import { PolicyUpdateComponent } from './policy/policy-update/policy-update.component';
import { SearchPolicyComponent } from './search/search-policy/search-policy.component';
import { SearchDisplayComponent } from './search/search-display/search-display.component';
import { MaturityCalcComponent } from './maturity-calc/maturity-calc.component';
import { ContactRegComponent } from './contact/contact-reg/contact-reg.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDisplayComponent,
    UserRegisterComponent,
    UserLoginComponent,
    NavComponent,
    HomeComponent,
    PolicyRegComponent,
    PolicyDisplayComponent,
    FooterComponent,
    PolicyUpdateComponent,
    SearchPolicyComponent,
    SearchDisplayComponent,
    MaturityCalcComponent,
    ContactRegComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
