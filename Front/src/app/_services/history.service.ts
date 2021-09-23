import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HistoryMaterial } from '../_models/HistoryMaterial';

const AUTH_API = `${environment.apiUrl}/History`;

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  constructor(private http: HttpClient) {}

  getHistory(value:Guid):Observable<any>{
    return this.http.get<HistoryMaterial[]>(`${AUTH_API}/Material/`+value);
  }
}
