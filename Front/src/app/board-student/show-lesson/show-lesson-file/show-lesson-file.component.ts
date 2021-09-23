import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { ClassesFile } from 'src/app/_models/ClassesFile';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { environment } from 'src/environments/environment';

const AUTH_API = `${environment.apiUrl}/file`;

@Component({
  selector: 'app-show-lesson-file',
  templateUrl: './show-lesson-file.component.html',
  styleUrls: ['./show-lesson-file.component.scss']
})
export class ShowLessonFileComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: ClassesFile,
    public dialogRef: MatDialogRef<ShowLessonFileComponent>,
    private http: HttpClient,
    private tokenStorageService: TokenStorageService,
  ) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  download(id:Guid){
    const user = this.tokenStorageService.getUser();
    window.location.href = AUTH_API + '/DownloadTaskStudent/'+user!.id +'/' + id;
  }
}
