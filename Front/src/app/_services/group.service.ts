import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GroupS } from '../_models/GroupS';
import { NewGroup } from '../_models/NewGroup';

const AUTH_API = `${environment.apiUrl}/group`;

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor(private http: HttpClient) {}

  addNew(value: NewGroup): Observable<any> {
    return this.http.post(AUTH_API + '/New', value, {
      observe: 'response',
    });
  }

  getFromSchool(id:Guid):Observable<any>{
    return this.http.get<GroupS[]>(AUTH_API + '/GetFromSchool/'+id);
  }
}
