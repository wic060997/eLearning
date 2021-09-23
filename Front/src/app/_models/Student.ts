import { Guid } from 'guid-typescript';
import { MaterialStudent } from './MaterialStudent';
import { School } from './school';
import { GroupStatic } from './static/GroupStatic';
import { SubjectTypsStudent } from './SubjectTypsStudent';

export class Student {
  id!: Guid;
  login!: string;
  imieNazwisko!: string;
  email!: string;
  nrIndex!: number;

  school!: School;

  group!: GroupStatic;

  subject!: SubjectTypsStudent[];
  materials!: MaterialStudent[];
}
