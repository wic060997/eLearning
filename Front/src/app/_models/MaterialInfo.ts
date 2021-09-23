import { Guid } from "guid-typescript";

export class MaterialInfo{
    id!:Guid;
    isActive!:boolean;
    dataActive!:string;
    localization!:string;
    name!:string;
}