import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialog,
} from '@angular/material/dialog';
import { ClassesFile } from 'src/app/_models/ClassesFile';
import { LessonFile } from 'src/app/_models/LessonFile';
import { LessonTyps } from 'src/app/_models/LessonTyps';
import { LessonService } from 'src/app/_services/lesson.service';
import { ShowLessonFileComponent } from './show-lesson-file/show-lesson-file.component';

@Component({
  selector: 'app-show-lesson',
  templateUrl: './show-lesson.component.html',
  styleUrls: ['./show-lesson.component.scss'],
})
export class ShowLessonStudComponent implements OnInit {
  lesson!: LessonFile;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: LessonTyps,
    public dialogRef: MatDialogRef<ShowLessonStudComponent>,
    public lessonService: LessonService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.lessonService.getInfoLesson(this.data.id).subscribe((data) => {
      this.lesson = data;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  showFile(clas: ClassesFile) {
    const dialogRef = this.dialog.open(ShowLessonFileComponent, {
      width: '800px',
      data: clas,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadData();
    });
  }
}
