import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { environment } from 'src/environments/environment';
import { LessonTyps } from '../_models/LessonTyps';
import { Student } from '../_models/Student';
import { TokenStorageService } from '../_services/token-storage.service';
import { UserService } from '../_services/user.service';
import { ShowLessonStudComponent } from './show-lesson/show-lesson.component';

const AUTH_API = `${environment.apiUrl}/file`;

@Component({
  selector: 'app-board-student',
  templateUrl: './board-student.component.html',
  styleUrls: ['./board-student.component.scss'],
})
export class BoardStudentComponent implements OnInit {
  student!: Student;
  load: boolean = false;

  constructor(
    private tokenStorageService: TokenStorageService,
    private usersService: UserService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.load = true;
    const user = this.tokenStorageService.getUser();
    this.usersService.getStudent(user!.id).subscribe((data) => {
      this.student = data;
      this.load = false;
      console.log(data);
    });
  }

  Download(id: Guid) {
    const user = this.tokenStorageService.getUser();
    window.location.href = AUTH_API + '/DownloadTaskStudent/'+user!.id +'/' + id;
  }

  showLesson(less: LessonTyps) {
    console.log(less);
    const dialogRef = this.dialog.open(ShowLessonStudComponent, {
      width: '800px',
      data: less,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadData();
    });
  }
}
