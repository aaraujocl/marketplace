import { Component, OnInit } from '@angular/core';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { PageModel } from 'src/app/core/models/page.model';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.css']
})
export class OfferListComponent implements OnInit {

  pageSize = 4;

  OffersResponse: any;

  listOffers: any;

  config: any;

  currentPage:number  = 1;

  itemsPerPage: number = 10;

  totalItems: number = 0;

  tableSize: number[] = [5, 10, 15, 20];

  pagingConfig: PageModel = new PageModel();

  constructor(private marketplaceService: MarketplaceApiService) { }

  ngOnInit(): void {

    this.pagingConfig = {
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage,
      totalItems: this.totalItems
    }

    this.getOffers();
  }

  getOffers(){

    this.marketplaceService.getOffers( this.pagingConfig.currentPage, this.pagingConfig.itemsPerPage).subscribe({
      next: (response) => {
        this.OffersResponse = response;
        this.listOffers = this.OffersResponse.data;
        //console.log('que trae ', JSON.stringify(this.OffersResponse.totalRecords)); 
        this.pagingConfig.totalItems = this.OffersResponse.totalRecords;
      }      
  });

  }

  onTableDataChange(event:any){
    this.pagingConfig.currentPage  = event;
    this.getOffers();
  }

  onTableSizeChange(event:any): void {
    this.pagingConfig.itemsPerPage = event.target.value;
    this.pagingConfig.currentPage = 1;
    this.getOffers();
  }
}
