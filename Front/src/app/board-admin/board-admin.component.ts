import {
  AfterViewInit,
  Component,
  NgModule,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { SchoolService } from '../_services/school.service';
import { School } from '../_models/school';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NewSchoolComponent } from './new-school/new-school.component';
import { MatDialog } from '@angular/material/dialog';
import { NewSchool } from '../_models/newSchool';

@Component({
  selector: 'app-board-admin',
  templateUrl: './board-admin.component.html',
  styleUrls: ['./board-admin.component.scss'],
})
export class BoardAdminComponent implements OnInit {
  user!: User[];
  userAdmin!: Array<User>;
  userAdministration!: Array<User>;
  userTeacher!: Array<User>;
  userStudent!: Array<User>;
  userBrak!: Array<User>;

  school!: School[];
  newSchoolElem!: NewSchool;

  constructor(
    private userService: UserService,
    private schoolService: SchoolService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {
    this.userAdmin = new Array<User>();
    this.userAdministration = new Array<User>();
    this.userTeacher = new Array<User>();
    this.userStudent = new Array<User>();
    this.userBrak = new Array<User>();
  }

  ngOnInit(): void {
    this.laodUsers();
    this.loadSchool();
  }

  refresh() {
    console.log(this.userStudent);
    this.laodUsers();
    this.loadSchool();
  }

  laodUsers() {
    this.userService.getAllUsers().subscribe((data) => {
      this.user = data;
      this.loadRoles(data);
    });
  }
  loadRoles(data: User[]) {
    data.forEach((element) => {
      if (element.rola.nazwa === 'ADMIN') {
        this.userAdmin.push(element);
      }
      if (element.rola.nazwa === 'TEACHER') {
        this.userTeacher.push(element);
      }
      if (element.rola.nazwa === 'ADMINISTRATION') {
        this.userAdministration.push(element);
      }
      if (element.rola.nazwa === 'STUDENT') {
        this.userStudent.push(element);
      }
      if (element.rola.nazwa === 'BRAK') {
        this.userBrak.push(element);
      }
    });
  }

  loadSchool() {
    this.schoolService.getAll()
    .subscribe((data) => {
      this.school = data;
    });
  }

  newSchool() {
    const dialogRef = this.dialog.open(NewSchoolComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadSchool();
    });
  }
}
