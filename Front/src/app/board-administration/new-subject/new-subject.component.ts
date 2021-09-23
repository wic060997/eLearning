import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthenticateResponse } from 'src/app/_models/authenticate_response';
import { NewSubject } from 'src/app/_models/new-subject';
import { SchoolService } from 'src/app/_services/school.service';
import { SubjectService } from 'src/app/_services/subject.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-new-subject',
  templateUrl: './new-subject.component.html',
  styleUrls: ['./new-subject.component.scss'],
})
export class NewSubjectComponent implements OnInit {
  subjectForm!: FormGroup;
  user!: AuthenticateResponse;

  constructor(
    public dialogRef: MatDialogRef<NewSubjectComponent>,
    private fb: FormBuilder,
    private tokenStorageService: TokenStorageService,
    private subjectService: SubjectService
  ) {
    this.createForm();
  }

  ngOnInit(): void {}

  createForm() {
    this.subjectForm = this.fb.group({
      name: ['', Validators.required],
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  save(value: any) {
    let school =  this.tokenStorageService.getSchool();
    if(school!==null){
      this.subjectService
      .add(new NewSubject(value.name, school))
      .subscribe((result) => {
        console.log(result);
        this.dialogRef.close();
      });
    }
  }
}
