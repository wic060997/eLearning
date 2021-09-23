import { Guid } from "guid-typescript";
import { Classes } from "./Classes";

export class Material{
    id!:Guid;
    classes!:Classes;
    isActive!:boolean;
    dataActive!:string;
    localization!:string;
    name!:string;
}