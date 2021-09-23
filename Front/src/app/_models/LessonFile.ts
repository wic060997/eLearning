import { Guid } from 'guid-typescript';
import { ClassesFile } from './ClassesFile';
import { SubjectStudent } from './SubjectStudent';
import { TeacherInfoD } from './TeacherInfoD';

export class LessonFile {
  id!: Guid;
  teacherInfo!: TeacherInfoD;
  subjectStudent!: SubjectStudent;
  typLesson!: string;
  time!: number;
  classes!: ClassesFile[];
}
