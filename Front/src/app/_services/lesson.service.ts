import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lesson } from '../_models/Lesson';
import { LessonFile } from '../_models/LessonFile';
import { LessonTyp } from '../_models/LessonTyp';
import { NewLesson } from '../_models/NewLesson';

const AUTH_API = `${environment.apiUrl}/Lesson`;

@Injectable({
  providedIn: 'root'
})
export class LessonService {

  constructor(private http: HttpClient) {}

  addNew(value: NewLesson): Observable<any> {
    return this.http.post(AUTH_API + '/New', value, {
      observe: 'response',
    });
  }

  getSubject(value:Guid):Observable<any>{
    return this.http.get<LessonTyp[]>(`${AUTH_API}/GetSubject/`+value);
  }
  getLesson(value:Guid):Observable<any>{
    return this.http.get<Lesson>(`${AUTH_API}/GetLesson/`+value);
  }

  getInfoLesson(value:Guid):Observable<any>{
    return this.http.get<LessonFile>(`${AUTH_API}/GetInfoLessons/`+value);
  }
}
