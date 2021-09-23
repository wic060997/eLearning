import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Material } from '../_models/Material';
import { MaterialInfo } from '../_models/MaterialInfo';

const AUTH_API = `${environment.apiUrl}/material`;

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  constructor(private http: HttpClient) {}

  getMaterialFromClasses(id:Guid):Observable<any>{
    return this.http.get<MaterialInfo[]>(AUTH_API + '/GetClasses/'+id);
  }

  delete(id:Guid):Observable<any>{
    return this.http.get(AUTH_API + '/Delete/' + id);
  }

  GetFromSchool(id:Guid):Observable<any>{
    return this.http.get<Material[]>(AUTH_API + '/GetFromSchool/'+id);
  }
}
