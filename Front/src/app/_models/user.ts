import { Guid } from 'guid-typescript';
import { GroupS } from './GroupS';
import { Rola } from './rola';
import { School } from './school';

export class User {
  id!: Guid;
  login!: string;
  imieNazwisko!: string;
  czyAktywny!: boolean;
  password!: string;
  email!: string;
  rola!: Rola;
  school!: School;
  nrIndex!: number;
  image!: string;
  groups!: GroupS;
}
