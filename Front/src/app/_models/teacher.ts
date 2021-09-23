import { Guid } from "guid-typescript";
import { User } from "./user";

export class Teacher {
    id!: Guid;
    user!:User;
    specjalize!:string;
  }