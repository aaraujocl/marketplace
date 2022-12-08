export class OfferModel {

  title: string = '';
  categoryid: number = 0;
  description: string = '';
  location: string = '';
  pictureurl: string = '';
  userid: number = 0;

  // TODO: Complete the offer model
  constructor(json: any = null) {

    if (json !== null) {
      this.title = json.title;
      this.categoryid = json.categoryid;
      this.description = json.description;
      this.location = json.location;
      this.pictureurl = json.pictureurl;
      this.userid = json.userid;

    }
  }
}
