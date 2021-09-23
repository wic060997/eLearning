import { Guid } from "guid-typescript";
import { TypsLessonStudent } from "./TypsLessonStudent";

export class SubjectTypsStudent{
    id!:Guid;
    name!:string;
    typs!:TypsLessonStudent[];
}