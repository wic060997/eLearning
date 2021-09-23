import { Guid } from 'guid-typescript';
import { MaterialInfo } from './MaterialInfo';
import { UserStudent } from './static/UserStudent';

export class HistoryMaterial {
  public id!: Guid;
  public dataDownloading!: string;
  public material!: MaterialInfo;
  public user!: UserStudent;
}
