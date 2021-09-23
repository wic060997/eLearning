import { Guid } from "guid-typescript";

export class NewLesson {
    public subject!: Guid;
    public teacher!: Guid;
    public group!: Guid;
    public time!: number;
    public typ!:number;
  
    constructor(
      subject:Guid,
      teacher:Guid,
      group:Guid,
      time:number,
      typ:string
    ){
      this.subject=subject;
      this.teacher=teacher;
      this.group=group;
      this.time=time;
      if(typ==='WYKLAD'){
          this.typ = 0;
      }
      if(typ==='CWICZENIA'){
        this.typ = 1;
    }
    if(typ==='PROJECT'){
        this.typ = 2;
    }
    }
  }