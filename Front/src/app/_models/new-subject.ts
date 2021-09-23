import { Guid } from 'guid-typescript';

export class NewSubject {
  name!: string;
  school!: Guid;

  constructor( name: string, school: Guid) {
    this.name = name;
    this.school = school;
  }
}
