import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceProviderService } from '../Services/service-provider.service';

@Component({
  selector: 'app-editservices',
  templateUrl: './editservices.component.html',
  styleUrls: ['./editservices.component.scss']
})
export class EditservicesComponent implements OnInit {

  public EditForm!: FormGroup;
  EditFormData: FormData = new FormData();
  isurl: any;
  url!: string
  id: any;
  product: any;
  serviceType: any
  constructor(private services: ServiceProviderService, private fb: FormBuilder, private activeRoute: ActivatedRoute, private router:Router) {}
  
  ngOnInit(){
    this.id = this.activeRoute.snapshot.paramMap.get('id');
    this.services.GetServiceById(this.id).subscribe((res) => {
      this.product = res;
      console.log(this.product);
      console.log(this.product.title);
      console.log(this.product['title']);
      this.EditForm = this.fb.group({
        Id:[this.product.id],
        Title: [this.product.title, [Validators.required]],
        Description: [this.product.description, [Validators.required]],
        Price: [this.product.price, [Validators.required]],
        Image: [this.product.image, [Validators.required]],
        Service: [this.product.serviceTypeId, [Validators.required]],
      })
    });
    this.services.getServiceType().subscribe((res) => {
      this.serviceType = res;
    })
  }

  get title(){
    return this.EditForm.controls['Title'];
  }

  get description(){
    return this.EditForm.controls['Description'];
  }

  get price(){
    return this.EditForm.controls['Price']
  }

  get image(){
    return this.EditForm.controls['Image']
  }


  EditService(value: any) {
    console.log(value);
  }

  handleFileInput(event: any) {
    this.EditFormData.append("image", event.target.files[0], event.target.files[0].name);
    var data = event.target.files[0]
    var render = new FileReader();
    render.onload = (event: any) => {
      this.url = event.target.result;
      this.isurl = true;
    }
    render.readAsDataURL(data);
  }

  goBack(){
    this.router.navigate(['servicesprovider']);
  }
}