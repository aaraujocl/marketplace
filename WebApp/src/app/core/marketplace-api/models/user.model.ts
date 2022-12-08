export class UserModel {

  id: number = 0;
  username: string = '';
  firstname: string = '';
  lastname: string = '';
  password: string = '';
  
  constructor(json: any = null) {

    if (json !== null) {
      this.id = json.id;
      this.username = json.username;
      this.firstname = json.firstname;
      this.lastname = json.lastname;
      this.password = json.password;
    }
  }
}
