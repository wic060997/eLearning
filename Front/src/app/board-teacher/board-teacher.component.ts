import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { InfoLesson } from '../_models/InfoLesson';
import { Lesson } from '../_models/Lesson';
import { LessonInfo } from '../_models/LessonInfo';
import { SubjectInfo } from '../_models/SubjectInfo';
import { TeacherInformation } from '../_models/TeacherInformation';
import { TypeInfo } from '../_models/TypeInfo';
import { LessonService } from '../_services/lesson.service';
import { TeacherService } from '../_services/teacher.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { ShowLessonComponent } from './show-lesson/show-lesson.component';

@Component({
  selector: 'app-board-teacher',
  templateUrl: './board-teacher.component.html',
  styleUrls: ['./board-teacher.component.scss'],
})
export class BoardTeacherComponent implements OnInit {
  teacher!: TeacherInformation;
  typs!: Array<string>;
  sortList!: Array<SubjectInfo>;
  lessonList!: Array<LessonInfo>;
  lesson!: Lesson;

  constructor(
    private tokenStorageService: TokenStorageService,
    public dialog: MatDialog,
    private teacherService: TeacherService,
    private lessonService: LessonService
  ) {
    this.typs = new Array<string>();
  }

  ngOnInit(): void {
    this.refresh();
  }

  refresh() {
    console.log(this.typs);
    const user = this.tokenStorageService.getUser();
    this.teacherService.getTeacher(user!.id).subscribe((data) => {
      this.teacher = data;
      this.getTyps(data);
    });
  }

  getTyps(value: TeacherInformation) {
    value.subject.forEach((element: SubjectInfo) => {
      element.types.forEach((typ: TypeInfo) => {
        if (this.checkExistType(typ.name) == false) {
          this.typs.push(typ.name);
        }
      });
    });
  }

  checkExistType(name: string): boolean {
    const status = this.typs.includes(name);
    return status;
  }

  sortSubject(typ: any): Array<SubjectInfo> {
    this.sortList = new Array<SubjectInfo>();

    this.teacher.subject.forEach((subject: SubjectInfo) => {
      subject.types.forEach((type: TypeInfo) => {
        if (type.name === typ) {
          if (this.checkExistSubject(subject) == false) {
            this.sortList.push(subject);
          }
        }
      });
    });
    return this.sortList;
  }

  checkExistSubject(type: SubjectInfo): boolean {
    const status = this.sortList.includes(type);
    return status;
  }

  getLessonWithTyp(subjects: SubjectInfo): Array<LessonInfo> {
    this.lessonList = new Array<LessonInfo>();

    subjects.types.forEach((x) => {
      x.lessonStatic.forEach((les) => {
        this.lessonList.push(les);
      });
    });

    return this.lessonList;
  }

  showLesson(less: LessonInfo, lesson: Lesson) {
    const dialogRef = this.dialog.open(ShowLessonComponent, {
      width: '800px',
      data: new InfoLesson(less, lesson),
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.refresh();
    });
  }

  loadLesson(less: LessonInfo) {
    this.lessonService.getLesson(less.id).subscribe((x) => {
      this.lesson = x;
      this.showLesson(less, x);
    });
  }
}
