import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NewTeacher } from '../_models/NewTeacher';
import { Teacher } from '../_models/teacher';
import { TeacherInformation } from '../_models/TeacherInformation';

const AUTH_API = `${environment.apiUrl}/teacher`;

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private http: HttpClient) {}

  addNew(value: NewTeacher): Observable<any> {
    return this.http.post(AUTH_API + '/NewTeacher', value, {
      observe: 'response',
    });
  }
  
  public get(value:Guid) :Observable<any>{
    return this.http.get<Teacher[]>(`${AUTH_API}/TeachersSchool/`+value);
  }

  public getTeacher(value:Guid):Observable<any>{
    return this.http.get<TeacherInformation>(`${AUTH_API}/GetInfoTeacher/`+value);
  }
}
