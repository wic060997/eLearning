import { Guid } from "guid-typescript";

export class RegistrationRequest {
    public login!: string;
    public password!: string;
    public imieNazwisko!: string;
    public email!: string;
    public school!:Guid;
  }