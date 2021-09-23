import { Guid } from "guid-typescript";
import { MaterialInfo } from "./MaterialInfo";

export class ClassesFile{
    id!:Guid;
    theme!:string;
    dataClasses!:string;
    materials!:MaterialInfo[];
}