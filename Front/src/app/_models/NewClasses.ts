import { Guid } from 'guid-typescript';

export class NewClasses {
  lessonId!: Guid;
  theme!: string;
  dataClasses!: Date;

  constructor(lesson: Guid, theme: string, data: Date) {
    this.lessonId = lesson;
    this.theme = theme;
    this.dataClasses = data;
  }
}
