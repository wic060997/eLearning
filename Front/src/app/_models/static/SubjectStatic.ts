import { Guid } from "guid-typescript";
import { TypsLessonStudent, TypsStatic } from "../TypsLessonStudent";
import { LessonStatic } from "./LessonStatic";

export class SubjectStatic {
    id!:Guid;
    name!:string;
    types!:TypsStatic[];
}