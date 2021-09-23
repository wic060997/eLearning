import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NewSubject } from '../_models/new-subject';
import { Subject } from '../_models/Subject';

const AUTH_API = `${environment.apiUrl}/subject`;

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  

  constructor(
    private http:HttpClient
  ) { }

  public add(value:NewSubject):Observable<any>{
    console.log(value);
    return this.http.post(AUTH_API , value, {
      observe: 'response',
    });
  }

  public get(value:Guid) :Observable<any>{
    return this.http.get<Subject[]>(`${AUTH_API}/school/`+value);
  }
}
