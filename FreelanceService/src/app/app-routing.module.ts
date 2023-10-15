import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProvidedServicesComponent } from './provided-services/provided-services.component';
import { AuthGuard } from './Guard/auth-guard.guard';
import { CustomerComponent } from './customer/customer.component';
import { EditservicesComponent } from './editservices/editservices.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

const routes: Routes = [
  
  {path:"", component:LoginComponent},
  {path:"login", component:LoginComponent},
  {path:"signup",component:SignUpComponent},
  {path:"forgotPassword",component:ForgotPasswordComponent},
  {path:"resetPassword",component:ResetPasswordComponent},
  {path:"servicesprovider",component:ProvidedServicesComponent, canActivate: [AuthGuard],
  data: {
    role: "ServiceProvider"
  }},
  {path:"editService/:id",component:EditservicesComponent, canActivate: [AuthGuard],
  data: {
    role: "ServiceProvider"
  }},
  {path:"customer",component:CustomerComponent, canActivate:[AuthGuard], data:{role:"Customer"}},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
