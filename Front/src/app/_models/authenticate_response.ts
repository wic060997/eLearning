import { Guid } from "guid-typescript";
import { Rola } from "./rola";
import { School } from "./school";

export class AuthenticateResponse {
    public id!: Guid;
    public login!: string;
    public rola!: Rola;
    public school!:School;
    public token!: string;
  }