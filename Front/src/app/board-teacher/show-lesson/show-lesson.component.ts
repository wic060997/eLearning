import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Classes } from 'src/app/_models/Classes';
import { InfoLesson } from 'src/app/_models/InfoLesson';
import { Lesson } from 'src/app/_models/Lesson';
import { LessonInfo } from 'src/app/_models/LessonInfo';
import { ClassesService } from 'src/app/_services/classes.service';
import { LessonService } from 'src/app/_services/lesson.service';
import { NewClassesComponent } from './new-classes/new-classes.component';
import { ShowFilesComponent } from './show-files/show-files.component';

@Component({
  selector: 'app-show-lesson',
  templateUrl: './show-lesson.component.html',
  styleUrls: ['./show-lesson.component.scss'],
})
export class ShowLessonComponent implements OnInit {
  lesson!: Lesson;
  classes!: Classes[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: InfoLesson,
    public dialogRef: MatDialogRef<ShowLessonComponent>,
    public dialog: MatDialog,
    public lessonService: LessonService,
    public classService: ClassesService
  ) {}

  ngOnInit(): void {
    this.refresh();
  }

  refresh() {
    this.lessonService.getLesson(this.data.lessonInfo.id).subscribe((x) => {
      this.lesson = x;
    });
    this.classService.getLesson(this.data.lessonInfo.id).subscribe((x) => {
      console.log(x);
      this.classes = x;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  newClasses() {
    const dialogRef = this.dialog.open(NewClassesComponent, {
      width: '220px',
      data: this.data.lesson.id,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.refresh();
    });
  }

  showFiles(value: Classes) {
    const dialogRef = this.dialog.open(ShowFilesComponent, {
      width: '800px',
      data: value,
    });
  }
  showDate(value: Date): any {
    console.log(value);
  }
}
