import { Guid } from "guid-typescript";

export class NewGroup {
    public year!: number;
    public semester!: number;
    public Direction!: string;
    public Specjalize!: string;
    public school!: Guid;
  
    constructor(
      year:number,
      semester:number,
      direction:string,
      specjalize:string,
      school:Guid
    ){
      this.year = year;
      this.semester =semester;
      this.Direction = direction;
      this.Specjalize = specjalize;
      this.school = school;
    }
  }