import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { SessionModel } from 'src/app/core/marketplace-api/models/session.model';
import { UserModel } from 'src/app/core/marketplace-api/models/user.model';
import { StorageService } from 'src/app/core/marketplace-api/storage.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup = new FormGroup({});
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private marketplaceService: MarketplaceApiService,
        private storageService: StorageService,
        private toastr: ToastrService,

        //private alertService: AlertService
    ) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
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
        this.marketplaceService.getUser(this.username?.value, this.password?.value)
           
            .subscribe({
                next: (response) => {
                    this.loading = false;
                    // get return url from query parameters or default to home page
                    //console.log(JSON.stringify(response))
                    
                    this.storageService.setCurrentSession(new SessionModel(response as UserModel));
                    //const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                    this.router.navigate(['/home/offer-creation']);
                },
                error: error => {
                  this.toastr.error('Error: Usuario o contraseña incorrecto o el usuario no existe' , 'Error', { enableHtml: true, closeButton: true });
                    //this.alertService.error(error);
                    this.loading = false;
                }
            });
    }
}