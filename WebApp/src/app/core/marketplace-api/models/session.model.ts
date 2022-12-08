import { UserModel } from "./user.model";

export class SessionModel {

  public user: UserModel;

  constructor(userin: UserModel = new UserModel()) {   
    this.user = userin;
  }
}
