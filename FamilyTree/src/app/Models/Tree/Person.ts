import { Base } from "../Base/base";

export class Person extends Base{
  familyId:number;
  parentId?:number;
  name:string;
  wifeName?:string;
  birthDate?:Date;
  parents?:string;
  imageName?:string;
  girlNums?:number;
}
