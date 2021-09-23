import { Guid } from "guid-typescript";
import { SubjectInfo } from "./SubjectInfo";
import { User } from "./user";

export class TeacherInformation {
    id!:Guid;
    specjalize!:string;
    user!:User;
    subject!:SubjectInfo[];
}