import { Guid } from "guid-typescript";

export class NewStudent {
    public idUser!: Guid;
    public idGroup!: Guid;
  
    constructor(
        idUser: Guid,
        idGroup: Guid
    ){
      this.idUser = idUser;
      this.idGroup = idGroup;
    }
  }