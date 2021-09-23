import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NewSchool } from '../_models/newSchool';
import { School } from '../_models/school';

const AUTH_API = `${environment.apiUrl}/school`;

@Injectable({
  providedIn: 'root',
})
export class SchoolService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<any> {
    return this.http.get<School[]>(`${AUTH_API}`);
  }

  addNew(value: NewSchool): Observable<any> {
    return this.http.post(AUTH_API + '/New', value, {
      observe: 'response',
    });
  }
}
