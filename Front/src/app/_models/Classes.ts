import { Guid } from "guid-typescript";
import { Lesson } from "./Lesson";

export class Classes{
    id!:Guid;
    lesson!:Lesson;
    theme!:string;
    dataClasses!:Date;
}