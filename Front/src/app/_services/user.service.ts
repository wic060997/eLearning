import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { Guid } from 'guid-typescript';
import { UserStatic } from '../_models/static/UserStatic';
import { ResponseSchoolStatic } from '../_models/static/ResponseSchoolStatic';
import { NewStudent } from '../_models/NewStudent';
import { UserStudent } from '../_models/static/UserStudent';
import { Student } from '../_models/Student';

const AUTH_API = `${environment.apiUrl}/users`;

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<any> {
    return this.http.get<User[]>(`${AUTH_API}/GetAll`);
  }

  getUserById(id: Guid): Observable<any> {
    return this.http.get<User>(`${AUTH_API}/get/`+id);
  }

  getSchool(id:Guid):Observable<any>{
    return this.http.get<ResponseSchoolStatic>(`${AUTH_API}/getSchool/`+id);
  }
  
  addStudent(value:NewStudent):Observable<any>{
    return this.http.post(AUTH_API + '/NewStudent', value, {
      observe: 'response',
    });
  }

  getGroup(id:Guid):Observable<any>{
    return this.http.get<UserStudent[]>(`${AUTH_API}/getGroup/`+id);
  }

  getStudent(id:Guid):Observable<any>{
    return this.http.get<Student>(`${AUTH_API}/getStudent/`+id);
  }
}
