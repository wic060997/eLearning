import { Guid } from "guid-typescript";
import { GroupStatic } from "./static/GroupStatic";

export class LessonInfo{
    id!:Guid;
    time!:number;
    groupStatic!:GroupStatic;
}