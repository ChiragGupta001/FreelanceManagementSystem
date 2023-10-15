import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { AccountService } from './Services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit{
  title = 'FreelanceService';
  loger!:boolean;
  islog:any;


  ngOnInit(): void { 
    this.primengConfig.ripple = true;
    this.account.loger.subscribe(res=>{
      this.loger = res;
    });
    this.islog = this.account.isLoggedIn();
    if(this.islog){
      this.account.loger.next(true);
    }else{
      this.router.navigate(['login']);
    }
  }
  constructor(private primengConfig: PrimeNGConfig, 
              private account: AccountService,
              private router: Router) {}

  logOut(){
   this.account.logout();
   localStorage.clear();
   this.account.loger.next(false);
   this.router.navigate(['login']);
  }

}
