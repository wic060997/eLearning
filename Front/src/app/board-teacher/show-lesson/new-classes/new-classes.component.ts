import {
  ChangeDetectionStrategy,
  Component,
  Inject,
  OnInit,
} from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { NewClasses } from 'src/app/_models/NewClasses';
import { ClassesService } from 'src/app/_services/classes.service';

@Component({
  selector: 'app-new-classes',
  templateUrl: './new-classes.component.html',
  styleUrls: ['./new-classes.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewClassesComponent implements OnInit {
  public today!: Date;

  themeString!: string;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Guid,
    public dialogRef: MatDialogRef<NewClassesComponent>,
    public dialog: MatDialog,
    private fb: FormBuilder,
    public classesService: ClassesService
  ) {}

  ngOnInit(): void {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  save() {
    this.classesService
      .addNew(new NewClasses(this.data, this.themeString, this.today))
      .subscribe((result) => {
        console.log(result);
        this.dialogRef.close();
      });
  }
}
