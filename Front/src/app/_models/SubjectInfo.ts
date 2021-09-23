import { Guid } from "guid-typescript";
import { TypeInfo } from "./TypeInfo";

export class SubjectInfo{
    id!:Guid;
    name!:string;
    types!:TypeInfo[];
}