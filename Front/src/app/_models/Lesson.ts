import { Guid } from "guid-typescript";
import { GroupS } from "./GroupS";
import { Subject } from "./Subject";
import { Teacher } from "./teacher";

export class Lesson{
    id!:Guid;
    groupS!:GroupS;
    teacher!:Teacher;
    subject!:Subject;
    typLesson!:number;
    time!:number;
}