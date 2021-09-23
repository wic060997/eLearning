import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewSchool } from 'src/app/_models/newSchool';
import { SchoolService } from 'src/app/_services/school.service';

@Component({
  selector: 'app-new-school',
  templateUrl: './new-school.component.html',
  styleUrls: ['./new-school.component.scss'],
})
export class NewSchoolComponent {
  schoolForm!: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<NewSchoolComponent>,
    private schoolService: SchoolService,
    private fb: FormBuilder
  ) {
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  save(value: any): void {
    this.schoolService
      .addNew(
        new NewSchool(
          value.name,
          value.login,
          value.imieNazwisko,
          value.password,
          value.email
        )
      )
      .subscribe((result) => {
        console.log(result);
        this.dialogRef.close();
      });
  }

  createForm() {
    this.schoolForm = this.fb.group({
      name: ['', Validators.required],
      login: ['', Validators.required],
      imieNazwisko: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
    });
  }
}
