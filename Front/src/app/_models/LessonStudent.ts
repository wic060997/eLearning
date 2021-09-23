import { Guid } from "guid-typescript";
import { SubjectStudent } from "./SubjectStudent";
import { TeacherInfoD } from "./TeacherInfoD";

export class LessonStudent{
    id!:Guid;
    userTeacher!:TeacherInfoD;
    subjectStudent!:SubjectStudent;
    typ!:string;
    time!:number;
}