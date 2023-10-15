import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../Services/account.service';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

export interface ResetPasswordDto {
  password: string;
  confirmPassword: string;
  email: string;
  token: string;
}

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})

export class ResetPasswordComponent {
  resetPasswordForm!: FormGroup;
  showSuccess!: boolean;
  showError!: boolean;
  errorMessage!: string;
  private token!: string;
  private email!: string;
  
  constructor(private authService: AccountService, 
              private fb :FormBuilder,
              private route: ActivatedRoute)
             { }
  
    ngOnInit(): void {
      this.resetPasswordForm = this.fb.group ({
        Password : ['', [Validators.required]],
        ConfirmPassword : ['']
    });
    
    // this.resetPasswordForm.get('confirm').setValidators([Validators.required,
    // this.passConfValidator.validateConfirmPassword(this.resetPasswordForm.get('password'))]);
    
      this.token = this.route.snapshot.queryParams['token'];
      this.email = this.route.snapshot.queryParams['email'];
  }




  public resetPassword = (resetPasswordFormValue: any) => {
    this.showError = this.showSuccess = false;
    const resetPass = { ... resetPasswordFormValue };
    const resetPassDto: ResetPasswordDto = {
      password: resetPass.password,
      confirmPassword: resetPass.confirm,
      token: this.token,
      email: this.email
    }
    this.authService.resetPassword(resetPassDto)
    .subscribe({
      next:(_) => this.showSuccess = true,
    error: (err: HttpErrorResponse) => {
      this.showError = true;
      this.errorMessage = err.message;
    }})
  }


  // resetPassword(value:any){

  // }
}
