import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { PaginatorModule } from 'primeng/paginator';
import  { ReactiveFormsModule } from "@angular/forms";
import { LoginComponent } from './login/login.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { AccountService } from './Services/account.service';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { FileUploadModule } from 'primeng/fileupload';
import { DropdownModule } from 'primeng/dropdown';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProvidedServicesComponent } from './provided-services/provided-services.component';
import { CustomerComponent } from './customer/customer.component';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { EditservicesComponent } from './editservices/editservices.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    ProvidedServicesComponent,
    CustomerComponent,
    EditservicesComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    InputNumberModule,
    InputTextModule,
    FileUploadModule,
    PaginatorModule,
    ButtonModule,
    DropdownModule,
    ToastModule,
    PasswordModule,
    ConfirmDialogModule,
    ReactiveFormsModule
  ],
  providers: [AccountService,ConfirmationService,MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
