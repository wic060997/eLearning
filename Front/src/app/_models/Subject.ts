import { Guid } from 'guid-typescript';
import { School } from './school';

export class Subject {
  id!: Guid;
  name!: string;
  school!: School;
}
