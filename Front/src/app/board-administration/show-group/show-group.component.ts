import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GroupS } from 'src/app/_models/GroupS';
import { UserStudent } from 'src/app/_models/static/UserStudent';
import { GroupService } from 'src/app/_services/group.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-show-group',
  templateUrl: './show-group.component.html',
  styleUrls: ['./show-group.component.scss']
})
export class ShowGroupComponent implements OnInit {
students!:UserStudent[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: GroupS,
    public dialogRef: MatDialogRef<ShowGroupComponent>,
    private fb: FormBuilder,
    private groupService:GroupService,
    private userService:UserService
  ) { }

  ngOnInit(): void {
    this.userService.getGroup(this.data.id)
    .subscribe(x=>{
      this.students=x;
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
