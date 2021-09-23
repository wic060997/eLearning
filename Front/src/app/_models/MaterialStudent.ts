import { Guid } from "guid-typescript";
import { ClassesStudent } from "./ClassesStudent";

export class MaterialStudent{
    id!:Guid;
    name!:string;
    localization!:string;
    dataActive!:string;
    classesStudent!:ClassesStudent;
}