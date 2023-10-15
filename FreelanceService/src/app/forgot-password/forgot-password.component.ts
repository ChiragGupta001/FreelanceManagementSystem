import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../Services/account.service';
import { ForgotPassword } from '../shared/forgotpassword';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})

export class ForgotPasswordComponent {
  forgotPasswordForm!: FormGroup
  successMessage!: string;
  errorMessage!: string;
  showSuccess!: boolean;
  showError!: boolean;
  
  constructor(private _authService: AccountService,private fb:FormBuilder) { }
  
  ngOnInit(): void {
    this.forgotPasswordForm = this.fb.group({
      Email: ["", [Validators.required]]
    })
  }

  get email(){
    return this.forgotPasswordForm.controls['Email'];
  }


  // public validateControl = (controlName: string) => {
  //   return this.forgotPasswordForm.controls.get ([controlName]).invalid && this.forgotPasswordForm.get(controlName).touched
  // }
  // public hasError = (controlName: string, errorName: string) => {
  //   return this.forgotPasswordForm.get(controlName).hasError(errorName)
  // }
  public forgotPassword = (forgotPasswordFormValue: any) => {
    debugger
    this.showError = this.showSuccess = false;
    const forgotPass = { ...forgotPasswordFormValue };
    const forgotPassDto: ForgotPassword = {
      email: forgotPass.Email,
      clientURI: 'http://localhost:4200/resetPassword'
    }
    this._authService.forgotPassword(forgotPassDto).subscribe((res)=>{
      this.showSuccess = true;
      this.successMessage = 'The link has been sent, please check your email to reset your password.';
    },
    (error)=>{
      this.showError = true;
      this.errorMessage = error.message;
    })
    // .subscribe() {
    //   this.showSuccess = true;
    //   this.successMessage = 'The link has been sent, please check your email to reset your password.'
    // },
    // error: (err: HttpErrorResponse) => {
    //   this.showError = true;
    //   this.errorMessage = err.message;
    // }})
  }
}
