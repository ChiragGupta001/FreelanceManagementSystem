import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../Services/account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  usertoken: any;
  roles:any;

  constructor(private fb: FormBuilder, private account: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.usertoken = localStorage.getItem("token");
    if(this.account.isLoggedIn()){
      this.account.loger.next(true);
    this.roles = this.account.decodeToken('role')
    if (this.roles == "ServiceProvider") {
      if (this.account.isLoggedIn()) {
        this.router.navigate(['servicesprovider']);
      } else {
        this.router.navigate(['login']);
      }
    } else if (this.roles == "Customer") {
      if (this.account.isLoggedIn()) {
        this.router.navigate(['customer']);
      } else {
        this.router.navigate(['login']);
      }
    }}
  }

  LoginForm: FormGroup = this.fb.group({
    Email: ['', Validators.required],
    Password: ['', Validators.required]
  });

  get email() {
    return this.LoginForm.controls["Email"];
  }

  get password() {
    return this.LoginForm.controls["Password"];
  }

  Login(value: string) {
    debugger
    this.account.Signin(value).subscribe((res) => {
      this.usertoken = res;
      localStorage.setItem("token", this.usertoken['token']);
      this.roles = this.account.decodeToken('role');
      this.account.login(this.roles);
      this.account.loger.next(true);
      if (this.roles == "ServiceProvider") {
        this.router.navigate(['servicesprovider']);
      } else if (this.roles == "Customer") {
        this.router.navigate(['customer']);
      }
    });
  }

  Register() {
    this.router.navigate(['signup']);
  }

  ForgotPassword(){
    this.router.navigate(['forgotPassword'])
  }

}