import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, of } from 'rxjs';
import { ForgotPassword } from '../shared/forgotpassword';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private jwtHelper:JwtHelperService;
  token:any;
  isLogin = false;
  loger = new BehaviorSubject<boolean>(false); 
  roleAs: string | null;

  constructor(private http:HttpClient) { 
    this.jwtHelper = new JwtHelperService(); 
    this.token = localStorage.getItem("token"); 
    this.roleAs = null;
  }

  url:string = "https://localhost:7199/api/";
  userLogin:any;

  Signin(value:string){
    return this.http.post(this.url+"Account/Login" , value);
  }

  decodeToken(claimKey:string){
    this.token = localStorage.getItem("token");
    var authToken = this.jwtHelper.decodeToken(this.token);
    return authToken[claimKey];
  }

  signUp(value:any){
    return this.http.post(this.url+"Account/Register" ,value);
  }

  login(value: string) {
    debugger
    this.isLogin = true;
    this.roleAs = value;
    localStorage.setItem('STATE', 'true');
    localStorage.setItem('ROLE', this.roleAs);
    return of({ success: this.isLogin, role: this.roleAs });
  }

  logout() {
    this.isLogin = false;
    this.roleAs = '';
    localStorage.setItem('STATE', 'false');
    localStorage.setItem('ROLE', '');
    return of({ success: this.isLogin, role: '' });
  }

  isLoggedIn() {
    const loggedIn = localStorage.getItem('STATE');
    if (loggedIn == 'true')
      this.isLogin = true;
    else
      this.isLogin = false;
    return this.isLogin;
  }
    
  getRole() {
    this.roleAs = localStorage.getItem('ROLE');
    return this.roleAs;
  }

  forgotPassword(forgotPassDto: ForgotPassword) {
    return this.http.post(this.url+"Customer/ForgotPassword",forgotPassDto)
  }

  resetPassword(value:any){
    return this.http.post(this.url+"Customer/ResetPassword",value);
  }
}
