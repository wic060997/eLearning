import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthenticateResponse } from 'src/app/_models/authenticate_response';
import { NewGroup } from 'src/app/_models/NewGroup';
import { GroupService } from 'src/app/_services/group.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-new-group',
  templateUrl: './new-group.component.html',
  styleUrls: ['./new-group.component.scss'],
})
export class NewGroupComponent implements OnInit {
  groupForm!: FormGroup;
  user!: AuthenticateResponse;

  constructor(
    public dialogRef: MatDialogRef<NewGroupComponent>,
    private fb: FormBuilder,
    private tokenStorageService: TokenStorageService,
    private groupService: GroupService
  ) {
    this.createForm();
  }

  ngOnInit(): void {}

  createForm() {
    this.groupForm = this.fb.group({
      year: ['', Validators.required],
      semester: ['', Validators.required],
      direction: ['', Validators.required],
      specjalize: ['', Validators.required],
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  save(value: any) {
    let school = this.tokenStorageService.getSchool();
    if (school !== null) {
      this.groupService
        .addNew(
          new NewGroup(
            Number(value.year),
            Number(value.semester),
            value.direction,
            value.specjalize,
            school
          )
        )
        .subscribe((result) => {
          console.log(result);
          this.dialogRef.close();
        });
    }
  }
}
