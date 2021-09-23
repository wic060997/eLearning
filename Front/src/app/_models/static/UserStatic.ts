import { Guid } from "guid-typescript";
import { GroupS } from "../GroupS";
import { Rola } from "../rola";
import { SubjectStatic } from "./SubjectStatic";

export class UserStatic {
    id!: Guid;
    imieNazwisko!: string;
    login!: string;
    email!: string;
    rola!:Rola;

    nrIndex!:number;
    group!:GroupS;

    specjalize!:string;
    subjectStatic!:SubjectStatic[];

  }