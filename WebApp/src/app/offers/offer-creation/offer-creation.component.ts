import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { CategoryModel } from 'src/app/core/marketplace-api/models/category.model';
import { StorageService } from 'src/app/core/marketplace-api/storage.service';

@Component({
  selector: 'app-offer-creation',
  templateUrl: './offer-creation.component.html',
  styleUrls: ['./offer-creation.component.css']
})
export class OfferCreationComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  loading = false;
  submitted = false;
  listCategory: any;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private marketplaceService: MarketplaceApiService
    
) { 
  this.getCategory();
}

ngOnInit() {
  this.form = this.formBuilder.group({
      title: ['', [Validators.required]],
      pictureurl: ['', [Validators.required]],
      description: ['', [Validators.required]],
      location: ['', [Validators.required]],
      categoryid: [null, [Validators.required]]
  });
}

get title() {
  return this.form.get('title');
}
get pictureurl() {
  return this.form.get('pictureurl');
}

get description() {
  return this.form.get('description');
}

get location() {
  return this.form.get('location');
}

get categoryid() {
  return this.form.get('categoryid');
}

getCategory(){

  this.marketplaceService.getCategories().subscribe({
    next: (response) => {

      this.listCategory = response as CategoryModel[];
      //console.log('que trae ', JSON.stringify(this.listCategory));       
    }
    
});

}

onSubmit() {

  const controls = this.form.controls;
  Object.keys(controls).forEach((controlName) => {
    controls[controlName].markAsTouched();
  });

  this.submitted = true;

  // reset alerts on submit
 // this.alertService.clear();

  // stop here if form is invalid
  if (this.form.invalid) {
      return;
  }

  this.loading = true;
  this.marketplaceService.postOffer(this.form.value)
      .subscribe({
          next: () => {
              
              //this.alertService.success('Registration successful', { keepAfterRouteChange: true });
              this.router.navigate(['../offer-list'], { relativeTo: this.route });
          },
          error: error => {
              //this.alertService.error(error);
              this.loading = false;
          }
      });
}
}
