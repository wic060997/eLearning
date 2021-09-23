import { Guid } from "guid-typescript";
import { UserTeacher } from "./UserTeacher";

export class TeacherInfoD{
    id!:Guid;
    user!:UserTeacher;
    specjalize!:string;
}