import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  url:string
  auth_token:any
  headers: HttpHeaders;
  constructor(private http:HttpClient) {
    this.url="https://localhost:7199/api/";
    this.auth_token = localStorage.getItem("token");
    this.headers = new HttpHeaders({'Content-Type': 'application/json'});
    this.headers = new HttpHeaders().set('Authorization', `Bearer ${this.auth_token}`);
  }

  GetServices(data:any){
    return this.http.get(this.url+`Customer/GetAllServices?pageIndex=${data.pageIndex}&pageSize=${data.pageSize}`,{headers: this.headers});
  }

  searchServices(value:any){
    return this.http.post(this.url+"Customer/GetSearch?search="+value,value,{headers: this.headers});
  }


}
