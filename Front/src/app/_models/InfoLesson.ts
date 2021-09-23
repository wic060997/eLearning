import { Lesson } from './Lesson';
import { LessonInfo } from './LessonInfo';

export class InfoLesson {
  lessonInfo!: LessonInfo;
  lesson!: Lesson;

  constructor(lessonInfo: LessonInfo, lesson: Lesson) {
    this.lessonInfo = lessonInfo;
    this.lesson = lesson;
  }
}
