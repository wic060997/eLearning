import { HttpClient, HttpEventType } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { Classes } from 'src/app/_models/Classes';
import { Material } from 'src/app/_models/Material';
import { MaterialInfo } from 'src/app/_models/MaterialInfo';
import { ClassesService } from 'src/app/_services/classes.service';
import { MaterialService } from 'src/app/_services/material.service';
import { environment } from 'src/environments/environment';
import { NewFilesComponent } from '../new-files/new-files.component';
import { ShowHistoryComponent } from './show-history/show-history.component';

const AUTH_API = `${environment.apiUrl}/file`;

@Component({
  selector: 'app-show-files',
  templateUrl: './show-files.component.html',
  styleUrls: ['./show-files.component.scss'],
})
export class ShowFilesComponent implements OnInit {
  materials!: Array<MaterialInfo>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Classes,
    public dialogRef: MatDialogRef<ShowFilesComponent>,
    public dialog: MatDialog,
    private fb: FormBuilder,
    public classesService: ClassesService,
    private http: HttpClient,
    public materialService: MaterialService
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.materialService
      .getMaterialFromClasses(this.data.id)
      .subscribe((data) => {
        this.materials = data;
      });
  }

  newFile() {
    const dialogRef = this.dialog.open(NewFilesComponent, {
      width: '300px',
      data: this.data,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadData();
    });
  }

  ShowList(id: Guid) {
    const dialogRef = this.dialog.open(ShowHistoryComponent, {
      width: '800px',
      data: id,
    });
  }

  deleteFile(id: Guid) {
    this.materialService.delete(id).subscribe((x) => {
      this.loadData();
    });
  }

  Download(id: MaterialInfo) {
    window.location.href = AUTH_API + '/DownloadTask/' + id.id;
  }
}
