import { Guid } from 'guid-typescript';
import { GroupS } from './GroupS';
import { Subject } from './Subject';
import { Teacher } from './teacher';

export class LessonTyp {
  public id!: Guid;
  public groupS!: GroupS;
  public teacher!: Teacher;
  public subject!: Subject;
  public typLesson!: string;
  public time!: number;
}
