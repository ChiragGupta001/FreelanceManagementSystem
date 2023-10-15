import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServiceProviderService {

  url:string
  auth_token:any
  headers: HttpHeaders;
  constructor(private http:HttpClient) {
    this.url="https://localhost:7199/api/";
    this.auth_token = localStorage.getItem("token");
    this.headers = new HttpHeaders({'Content-Type': 'application/json'});
    this.headers = new HttpHeaders().set('Authorization', `Bearer ${this.auth_token}`)
   }
  
  getService(data:any){
    return this.http.get(this.url+`ServiceProvider/GetAllServices?pageIndex=${data.pageIndex}&pageSize=${data.pageSize}`,{headers: this.headers});
  }

  getServiceType(){
    return this.http.get(this.url+"ServiceProvider/GetServiceType",{headers: this.headers});
  }

  CreateService(data:any){
    return this.http.post(this.url+"ServiceProvider/CreateService",data,{headers: this.headers});
  }

    GetServiceById(id:any)
    {
      return this.http.get(this.url+"ServiceProvider/GetById/"+id, {headers:this.headers})
    }

    UpdateService(data:any){
      return this.http.post(this.url+"ServiceProvider/EditService",data,{headers:this.headers})
    }

    DeleteDervice(id:any){
      return this.http.post(this.url+"ServiceProvider/DeleteService?id="+id,id,{headers:this.headers})
    }
}
