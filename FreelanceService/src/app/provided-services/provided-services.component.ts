import { Component, OnInit } from '@angular/core';
import { ServiceProviderService } from '../Services/service-provider.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../Services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmEventType, ConfirmationService, MessageService } from 'primeng/api';

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
  selector: 'app-provided-services',
  templateUrl: './provided-services.component.html',
  styleUrls: ['./provided-services.component.scss'],
  providers: [ConfirmationService, MessageService]
})

export class ProvidedServicesComponent implements OnInit {
  products: any;
  item: any;
  id: any;
  type: any;
  serviceType: any;
  CreateFormData: FormData;
  EditFormData: FormData;
  EditForm!: FormGroup;
  userId!: string;
  url!: string;
  isurl: boolean = false;
  first:number;
  rows:number;
  totalcount!:number;
  Paginator!: IPaginator;

  constructor(private services: ServiceProviderService,
    private fb: FormBuilder,
    private account: AccountService,
    private router: Router,
    private confirmationService: ConfirmationService,
    private messageService: MessageService) {
    this.CreateFormData = new FormData();
    this.EditFormData = new FormData();
    this.Paginator = {
      pageIndex: 1,
      pageSize: 4
  };
    this.first = 1;
    this.rows = 4;
  }

  ngOnInit() {
    debugger
    this.services.getService(this.Paginator).subscribe((res:any) => {
      this.products = res['list'];
      this.totalcount = res['totalCount'];
    });

    this.services.getServiceType().subscribe((res) => {
      this.serviceType = res;
      console.log(this.serviceType);
    });
    this.userId = this.account.decodeToken("Id");
  }

  CreateForm: FormGroup = this.fb.group({
    Title: ['', [Validators.required]],
    Description: ['', [Validators.required]],
    Price: [, [Validators.required]],
    Image: [File, [Validators.required]],
    Service: ['', [Validators.required]],
    UserId: []
  })

  get title() {
    return this.CreateForm.controls['Title'];
  }

  get description() {
    return this.CreateForm.controls['Description'];
  }

  get price() {
    return this.CreateForm.controls['Price']
  }

  get image() {
    return this.CreateForm.controls['Image']
  }

  handleFileInput(event: any) {
    this.CreateFormData.append("image", event.target.files[0], event.target.files[0].name);
    var data = event.target.files[0]
    var render = new FileReader();
    render.onload = (event: any) => {
      this.url = event.target.result;
      this.isurl = true;
    }
    render.readAsDataURL(data);
  }


  CreateService(value: any) {
    this.CreateFormData.append("Title", value.Title);
    this.CreateFormData.append("Description", value.Description);
    this.CreateFormData.append("price", value.Price);
    this.CreateFormData.append("serviceTypeId", value.Service['id']);
    this.CreateFormData.append("userId", this.userId);
    this.services.CreateService(this.CreateFormData).subscribe((res) => {
      console.log(res);
    })
  }


  onPageChange(event: PageEvent) {
    debugger
    this.first = event.first;
    this.Paginator.pageIndex = event.page+1;
    this.rows = event.rows;
    this.Paginator.pageSize = this.rows;
    this.services.getService(this.Paginator).subscribe((res:any) => {
      this.products = res['list'];
      this.totalcount = res['totalCount'];
    });
    }

  GetEditService(item: any) {
    this.router.navigate(['editService', item.id]);
  }

  confirm(item: any) {
    this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.services.DeleteDervice(item.id);
        this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
      },
      reject: () => {
        setTimeout(() => {
          this.messageService.add({ severity: 'error', summary: 'Something Went Wrong', detail: 'Product is not deleted' });
        }, 300);
      }
    })
  }
}
