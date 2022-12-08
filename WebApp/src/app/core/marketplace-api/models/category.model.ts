export class CategoryModel {

  id: number = 0;
  name: string = '';

  
  constructor(json: any = null) {

    if (json !== null) {
      this.id = json.id;
      this.name = json.name;
    }
  }
}
