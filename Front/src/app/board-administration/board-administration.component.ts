import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GroupS } from '../_models/GroupS';
import { Material } from '../_models/Material';
import { ResponseSchoolStatic } from '../_models/static/ResponseSchoolStatic';
import { UserStatic } from '../_models/static/UserStatic';
import { Subject } from '../_models/Subject';
import { GroupService } from '../_services/group.service';
import { MaterialService } from '../_services/material.service';
import { SubjectService } from '../_services/subject.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { UserService } from '../_services/user.service';
import { ChangeRoleComponent } from './change-role/change-role.component';
import { NewGroupComponent } from './new-group/new-group.component';
import { NewSubjectComponent } from './new-subject/new-subject.component';
import { ShowGroupComponent } from './show-group/show-group.component';
import { ShowSubjectComponent } from './show-subject/show-subject.component';

@Component({
  selector: 'app-board-administration',
  templateUrl: './board-administration.component.html',
  styleUrls: ['./board-administration.component.scss'],
})
export class BoardAdministrationComponent implements OnInit {
  dataStatic!: ResponseSchoolStatic;
  dataUsers!: UserStatic[];
  dataNullPermision: UserStatic[] = [];
  dataTeacher: UserStatic[] = [];
  dataStudent: UserStatic[] = [];

  dataGroup!: GroupS[];
  dataSubject!: Subject[];
  dataMaterial!:Material[];

  constructor(
    private tokenStorageService: TokenStorageService,
    private userService: UserService,
    public dialog: MatDialog,
    private subjectService: SubjectService,
    private groupService: GroupService,
    private materialService:MaterialService
  ) {}

  ngOnInit(): void {
    this.refresh();
  }

  refresh() {
    const user = this.tokenStorageService.getUser();

    this.userService.getSchool(user!.school.id).subscribe((data) => {
      this.dataStatic = data;
      this.dataUsers = data.users;
      this.sortUsers(data.users);
    });
    this.subjectService.get(user!.school.id).subscribe((data) => {
      this.dataSubject = data;
    });

    this.groupService.getFromSchool(user!.school.id).subscribe((data) => {
      this.dataGroup = data;
    });

    this.materialService.GetFromSchool(user!.school.id)
      .subscribe(data=>{
        this.dataMaterial=data;
      })
  }

  sortUsers(data: UserStatic[]) {
    for (let elem of data) {
      if (elem.rola.nazwa === 'BRAK') {
        this.dataNullPermision.push(elem);
      }
      if (elem.rola.nazwa === 'STUDENT') {
        this.dataStudent.push(elem);
      }
      if (elem.rola.nazwa === 'TEACHER') {
        this.dataTeacher.push(elem);
      }
    }
  }

  changeButton(value: any) {
    const dialogRef = this.dialog.open(ChangeRoleComponent, {
      width: '250px',
      data: value,
    });

    dialogRef.afterClosed().subscribe((result) => {
      const user = this.tokenStorageService.getUser();
      this.subjectService.get(user!.school.id).subscribe((data) => {
        this.dataSubject = data;
      });
    });
  }

  newSubject() {
    const dialogRef = this.dialog.open(NewSubjectComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      const user = this.tokenStorageService.getUser();
      this.subjectService.get(user!.school.id).subscribe((data) => {
        this.dataSubject = data;
        console.log(data);
      });
    });
  }
  newGroup() {
    const dialogRef = this.dialog.open(NewGroupComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      const user = this.tokenStorageService.getUser();
      this.groupService.getFromSchool(user!.school.id).subscribe((data) => {
        this.dataGroup = data;
      });
    });
  }

  showSubject(value: Subject) {
    const dialogRef = this.dialog.open(ShowSubjectComponent, {
      width: '500px',
      data: value,
    });
  }

  showStudents(value: GroupS) {
    const dialogRef = this.dialog.open(ShowGroupComponent, {
      width: '500px',
      data: value,
    });
  }
  test(les:any){
    console.log(les);
  }
}
