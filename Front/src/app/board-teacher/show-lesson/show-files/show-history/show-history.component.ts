import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { Classes } from 'src/app/_models/Classes';
import { HistoryMaterial } from 'src/app/_models/HistoryMaterial';
import { HistoryService } from 'src/app/_services/history.service';

@Component({
  selector: 'app-show-history',
  templateUrl: './show-history.component.html',
  styleUrls: ['./show-history.component.scss'],
})
export class ShowHistoryComponent implements OnInit {
history!:Array<HistoryMaterial>;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Guid ,
    public dialogRef: MatDialogRef<ShowHistoryComponent>,
    public dialog: MatDialog,
    public historyService: HistoryService
  ) {}

  ngOnInit(): void {
    this.historyService.getHistory(this.data).subscribe(data=>{
      this.history = data;
    });
  }
}
