import {Injectable} from "@angular/core";
import { Router } from '@angular/router';
import { SessionModel } from "./models/session.model";
import { UserModel } from "./models/user.model";

@Injectable()
export class StorageService {

  private localStorageService;
  private currentSession : SessionModel;

  constructor(private router: Router) {
    this.localStorageService = localStorage;
    this.currentSession = this.loadSessionData();
  }

  setCurrentSession(session: SessionModel): void {
    this.currentSession = session;
    this.localStorageService.setItem('currentUser', JSON.stringify(session));
  }

  loadSessionData(){
    let current = this.localStorageService.getItem('currentUser');
    return current !== null ? JSON.parse(current) : new SessionModel();
  }

  getCurrentSession(): SessionModel {
    return this.currentSession;
  }



  getCurrentUser(): UserModel {
    var session: SessionModel = this.getCurrentSession();
    return session.user;
  };


  isAuthenticated(): boolean {
    return (this.getCurrentUser() != null) ? true : false;
  };

 
}