import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private marketplaceService: MarketplaceApiService
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
        firstname: ['', [Validators.required]],
        lastname: ['', [Validators.required]],
        username: ['', [Validators.required]],
        password: ['', [Validators.required, Validators.minLength(6)]]
    });
}

// convenience getter for easy access to form fields
get firstname() {
  return this.form.get('firstname');
}

get lastname() {
  return this.form.get('lastname');
}

get username() {
  return this.form.get('username');
}

get password() {
  return this.form.get('password');
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
  this.marketplaceService.postUser(this.form.value)
      .subscribe({
          next: () => {
              //this.alertService.success('Registration successful', { keepAfterRouteChange: true });
              this.router.navigate(['../login'], { relativeTo: this.route });
          },
          error: error => {
              //this.alertService.error(error);
              this.loading = false;
          }
      });
}
  
}
