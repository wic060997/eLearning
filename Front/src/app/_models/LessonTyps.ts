import { Guid } from "guid-typescript";
import { TeacherInfoD } from "./TeacherInfoD";

export class LessonTyps{
    id!:Guid;
    userTeacher!:TeacherInfoD;
    time!:number;
}