import { Guid } from "guid-typescript";
import { LessonStudent } from "./LessonStudent";

export class ClassesStudent{
    id!:Guid;
    theme!:string;
    dataClasses!:Date;
    lessonStudent!:LessonStudent;
}