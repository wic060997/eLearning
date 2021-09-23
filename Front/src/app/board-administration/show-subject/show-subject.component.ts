import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { LessonTyp } from 'src/app/_models/LessonTyp';
import { Subject } from 'src/app/_models/Subject';
import { LessonService } from 'src/app/_services/lesson.service';
import { SubjectService } from 'src/app/_services/subject.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { NewLessonComponent } from './new-lesson/new-lesson.component';

export interface SubjectGuid {
  id: Guid;
}

@Component({
  selector: 'app-show-subject',
  templateUrl: './show-subject.component.html',
  styleUrls: ['./show-subject.component.scss'],
})
export class ShowSubjectComponent implements OnInit {
  public lessons!:LessonTyp[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Subject,
    public dialogRef: MatDialogRef<ShowSubjectComponent>,
    private tokenStorageService: TokenStorageService,
    private subjectService: SubjectService,
    public dialog: MatDialog,
    public lessonService: LessonService
  ) {
  }

  ngOnInit(): void {
    this.lessonService.getSubject(this.data.id).subscribe((x) => {
      this.lessons = x;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  newLesson() {
    const dialogRef = this.dialog.open(NewLessonComponent, {
      width: '500px',
      data: this.data,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.lessonService.getSubject(this.data.id).subscribe((x) => {
        this.lessons = x;
      });
    });
  }
}
