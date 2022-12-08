import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OfferListComponent } from './offer-list/offer-list.component';
import { OfferCreationComponent } from './offer-creation/offer-creation.component';

const routes: Routes = [
  
  {
    path: '',
    component: OfferListComponent
  },
  {
    path: 'offer-list',
    component: OfferListComponent
  },
  {
    path: 'offer-creation',
    component: OfferCreationComponent
  }
  
  
  
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OffersRoutingModule { }
