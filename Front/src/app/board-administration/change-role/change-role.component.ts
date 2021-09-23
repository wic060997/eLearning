import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GroupS } from 'src/app/_models/GroupS';
import { NewStudent } from 'src/app/_models/NewStudent';
import { NewTeacher } from 'src/app/_models/NewTeacher';
import { UserStatic } from 'src/app/_models/static/UserStatic';
import { GroupService } from 'src/app/_services/group.service';
import { TeacherService } from 'src/app/_services/teacher.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-change-role',
  templateUrl: './change-role.component.html',
  styleUrls: ['./change-role.component.scss'],
})
export class ChangeRoleComponent implements OnInit {
  chooseRole!: string;
  roles: string[] = ['STUDENT', 'TEACHER'];

  techerForm!: FormGroup;

  selectedGroup!: GroupS;
  groups!: GroupS[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: UserStatic,
    public dialogRef: MatDialogRef<ChangeRoleComponent>,
    private fb: FormBuilder,
    private tokenStorageService: TokenStorageService,
    private userService: UserService,
    private groupService: GroupService,
    private teacherService: TeacherService
  ) {}

  ngOnInit(): void {
    this.chooseRole = 'STUDENT';
    this.createForm();
    this.loadGroup();
  }

  createForm() {
    this.techerForm = this.fb.group({
      specjalize: ['', Validators.required],
    });
  }

  loadGroup() {
    let school = this.tokenStorageService.getSchool();
    if (school !== null) {
      this.groupService.getFromSchool(school).subscribe((result) => {
        this.groups = result;
      });
    }
  }

  onNoClick(): void {
    console.log(this.selectedGroup);
    this.dialogRef.close();
  }

  save() {
    this.userService
      .addStudent(new NewStudent(this.data.id, this.selectedGroup.id))
      .subscribe((result) => {
        this.dialogRef.close();
      });
  }

  saveTeacher(value: any) {
    this.teacherService
      .addNew(new NewTeacher(this.data.id, value.specjalize))
      .subscribe((result) => {
        this.dialogRef.close();
      });
  }
}
