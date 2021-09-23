import { Guid } from "guid-typescript";
import { GroupStatic } from "./GroupStatic";


export class LessonStatic{
    id!:Guid;
    time!:number;
    groupStatic!:GroupStatic[];
}