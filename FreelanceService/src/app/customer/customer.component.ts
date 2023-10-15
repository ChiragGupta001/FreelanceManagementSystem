import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../Services/customer.service';
import { FormBuilder, FormGroup } from '@angular/forms';

interface IPaginator{
  pageIndex:number,
  pageSize:number
}
interface PageEvent {
  first: number;
  rows: number;
  page: number;
  pageCount: number;
}

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
services:any
pageNumber:number;
first: number;
rows: number;
totalcount:number;
Paginator!: IPaginator;

constructor(private customer:CustomerService,
            private fb:FormBuilder )
            {
              this.Paginator = {
                pageIndex: 1,
                pageSize: 4
              };
              this.first = 1;
              this.rows = 4;
              this.pageNumber = 1
              this.totalcount = 1
            }


ngOnInit(): void {
  this.customer.GetServices(this.Paginator).subscribe((res:any)=>{
    this.services = res['list']
    console.log(res);
    this.pageNumber = res['pageIndex']
    this.totalcount = res['totalCount']
    console.log(this.services)
  })
}

onPageChange(event: PageEvent) {
  this.first = event.first;
  this.Paginator.pageIndex = event.page+1;
  this.rows = event.rows;
  this.Paginator.pageSize = this.rows;
  this.customer.GetServices(this.Paginator).subscribe((res:any)=>{
    this.services = res['list']
    this.pageNumber = res['pageIndex']
    this.totalcount = res['totalCount']
  })
}

search(value:any){
  if(value==""){
    this.customer.GetServices(this.Paginator).subscribe((res:any)=>{
      this.services = res['list'];
      this.pageNumber = res['pageIndex']
      this.totalcount = res['totalCount']
    })
  }else{
  this.customer.searchServices(value).subscribe((res)=>{
    this.services = res;
  })}
}


MailForm : FormGroup = this.fb.group({
  To:[],
  From:[],
  Subject:[],
  Body:[]
})

SendMail() {}

}
