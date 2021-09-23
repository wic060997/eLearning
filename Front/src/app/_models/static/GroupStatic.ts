import { Guid } from "guid-typescript";
import { UserStudent } from "./UserStudent";


export class GroupStatic{
    id!:Guid;
    year!:number;
    semester!:number;
    direction!:string;
    specjalize!:string;
    userStudent!:UserStudent[];
}