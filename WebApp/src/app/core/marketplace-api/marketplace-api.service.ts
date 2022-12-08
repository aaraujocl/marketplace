import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {OfferModel} from './models/offer.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserModel } from './models/user.model';
import { CategoryModel } from './models/category.model';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class MarketplaceApiService {

  private readonly marketplaceApUrl = environment.urlMarketplace;

  constructor(private httpClient: HttpClient,
              private storageService: StorageService) { }

  getOffers(page: number, pageSize: number): Observable<OfferModel[]> {
    // TODO: implement the logic to retrieve paginated offers from the service
    const httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    const endpoint: any = this.marketplaceApUrl + 'Offer?PageNumber='+page+'&PageSize='+pageSize;
    return this.httpClient.get<OfferModel[]>(endpoint, {headers: httpHeaders});
    
  }

  postOffer(offer: OfferModel){
    // TODO: implement the logic to post a new offer, also validate whatever you consider before posting
    console.log(JSON.stringify(offer));

    let user = this.storageService.getCurrentUser();

    const body = {
      categoryId: offer.categoryid,
      description: offer.description,
      location: offer.location,
      pictureUrl: offer.pictureurl,      
      title: offer.title,  
      userId: user.id
    }

    const httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    const endpoint: any = this.marketplaceApUrl + 'Offer';
    return this.httpClient.post(endpoint, JSON.stringify(body), { headers: httpHeaders });
  }

  postUser(user: UserModel){
    //console.log(JSON.stringify(user));
    const body = {
      username: user.username,
      firstname: user.firstname,
      lastname: user.lastname,
      password: user.password
    }

    const httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    const endpoint: any = this.marketplaceApUrl + 'User';
    return this.httpClient.post(endpoint, JSON.stringify(body), { headers: httpHeaders });
  }

  getUser(username: string, password: string) {
    // TODO: implement the logic to retrieve the user from the service

    const httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    const endpoint: any = this.marketplaceApUrl + 'User/' + username+'/'+password;
    return this.httpClient.get(endpoint, { headers: httpHeaders });
  }

  getCategories(): Observable<CategoryModel[]> {
    // TODO: implement the logic to retrieve the categories from the service
    const httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    const endpoint: any = this.marketplaceApUrl + 'Category';
    return this.httpClient.get<CategoryModel[]>(endpoint, {headers: httpHeaders});
  }
}
