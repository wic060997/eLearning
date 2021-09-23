import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { Classes } from 'src/app/_models/Classes';
import { environment } from 'src/environments/environment';

const AUTH_API = `${environment.apiUrl}/File`;

@Component({
  selector: 'app-new-files',
  templateUrl: './new-files.component.html',
  styleUrls: ['./new-files.component.scss'],
  providers: [DatePipe],
})
export class NewFilesComponent implements OnInit {
  fileName = '';
  public today!: Date;
  nameFile!: string;

  file!: File;

  checked1 = false;
  checked2 = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Classes,
    public dialogRef: MatDialogRef<NewFilesComponent>,
    public dialog: MatDialog,
    private http: HttpClient,
    public datepipe: DatePipe
  ) {}

  ngOnInit(): void {}

  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      this.fileName = file.name;

      this.file = file;
    }
  }

  upload() {
    const formData = new FormData();

    formData.append('thumbnail', this.file);

    if (this.checked1 === false) {
      if (this.checked2 === false) {
        const upload$ = this.http.post(
          AUTH_API + '/file/' + this.data.id + '/null/null',
          formData
        );
        upload$.subscribe(() => {
          this.dialogRef.close();
        });
      } else {
        const upload$ = this.http.post(
          AUTH_API +
            '/file/' +
            this.data.id +
            '/null/' +
            this.datepipe.transform(this.today, 'yyyy-MM-dd'),
          formData
        );
        upload$.subscribe(() => {
          this.dialogRef.close();
        });
      }
    } else {
      if (this.checked2 === false) {
        const upload$ = this.http.post(
          AUTH_API + '/file/' + this.data.id + '/' + this.nameFile + '/null',
          formData
        );
        upload$.subscribe(() => {
          this.dialogRef.close();
        });
      } else {
        const upload$ = this.http.post(
          AUTH_API +
            '/file/' +
            this.data.id +
            '/' +
            this.nameFile +
            '/' +
            this.datepipe.transform(this.today, 'yyyy-MM-dd'),
          formData
        );
        upload$.subscribe(() => {
          this.dialogRef.close();
        });
      }
    }
  }

  download(id: Guid) {
    this.http.get(AUTH_API + '/file/' + id, {});
  }
}
