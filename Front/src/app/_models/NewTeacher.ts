import { Guid } from "guid-typescript";

export class NewTeacher {
    public idUser!: Guid;
    public specjalize!: string;
  
    constructor(
        idUser: Guid,
        specjalize: string
    ){
      this.idUser = idUser;
      this.specjalize = specjalize;
    }
  }