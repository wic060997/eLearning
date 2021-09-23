import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GroupS } from 'src/app/_models/GroupS';
import { NewLesson } from 'src/app/_models/NewLesson';
import { Subject } from 'src/app/_models/Subject';
import { Teacher } from 'src/app/_models/teacher';
import { GroupService } from 'src/app/_services/group.service';
import { LessonService } from 'src/app/_services/lesson.service';
import { TeacherService } from 'src/app/_services/teacher.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-new-lesson',
  templateUrl: './new-lesson.component.html',
  styleUrls: ['./new-lesson.component.scss']
})
export class NewLessonComponent implements OnInit {

  chooseTyp!: string;
  types: string[] = ['WYKLAD','CWICZENIA', 'PROJECT',];

  selectTeacher!:Teacher;
  teachers!:Teacher[];

  selectGroup!:GroupS;
  groups!:GroupS[];

  timeValue!:number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Subject,
    public dialogRef: MatDialogRef<NewLessonComponent>,
    private tokenStorageService: TokenStorageService,
    private teacherService:TeacherService,
    private groupService:GroupService,
    private lessonService:LessonService
  ) { }

  ngOnInit(): void {
    this.teacherService.get(this.data.school.id)
    .subscribe((result)=>{
      this.teachers=result;
    });

    this.groupService.getFromSchool(this.data.school.id)
    .subscribe(result=>{
      this.groups = result;
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  save(){

this.lessonService.addNew(new NewLesson(
  this.data.id,
  this.selectTeacher.id,
  this.selectGroup.id,
  this.timeValue,
  this.chooseTyp
)).subscribe(result=>{
  console.log(result);
        this.dialogRef.close();
})
  }
}
