import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferCreationComponent } from './offer-creation/offer-creation.component';
import { OfferItemComponent } from './offer-item/offer-item.component';
import { OfferListComponent } from './offer-list/offer-list.component';
import { OffersRoutingModule } from './offers-routing.module';
import { OffersComponent } from './offers.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';



@NgModule({
  declarations: [
    OfferCreationComponent,
    OfferItemComponent,
    OfferListComponent,
    OffersComponent
  ],
  imports: [
    CommonModule,
    OffersRoutingModule,
    NgxPaginationModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class OffersModule { }
