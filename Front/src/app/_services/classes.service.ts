import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Classes } from '../_models/Classes';
import { NewClasses } from '../_models/NewClasses';


const AUTH_API = `${environment.apiUrl}/classes`;

@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  constructor(private http: HttpClient) {}

  addNew(value: NewClasses): Observable<any> {
    return this.http.post(AUTH_API + '/NewClasses', value, {
      observe: 'response',
    });
  }

  getLesson(id:Guid):Observable<any>{
    return this.http.get<Classes[]>(AUTH_API + '/GetLesson/'+id);
  }
}
