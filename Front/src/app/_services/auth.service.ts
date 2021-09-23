import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticateRequest } from '../_models/authenticate_request';
import { RegistrationRequest } from '../_models/registration_request';
import { TokenStorageService } from './token-storage.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../_models/user';
import { Guid } from 'guid-typescript';

const AUTH_API = `${environment.apiUrl}/users`;

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public user!: Observable<User>;

  constructor(
    private http: HttpClient,
    private tokenStorageService: TokenStorageService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  login(login: string, password: string): any {
    const request = new AuthenticateRequest();
    request.login = login;
    request.password = password;
    let response;

    this.http
      .post<any>(AUTH_API + '/authenticate', request, httpOptions)
      .subscribe((data) => {
        response = data;
        this.tokenStorageService.saveUser(response);

        if (
          response.rola.id.toUpperCase() ===
          'AC634082-8D93-4C54-B144-967FCDE35DF9'
        ) {
          this.router.navigate(['/admin']);
        }
        if (
          response.rola.id.toUpperCase() ===
          '75944EBD-854D-4ACE-B991-9471E98C9233'
        ) {
          this.router.navigate(['/student']);
        }
        if (
          response.rola.id.toUpperCase() ===
          'BC01F1AC-2389-4CFD-9D68-CA28FCB72C2F'
        ) {
          this.router.navigate(['/teacher']);
        }
        if (
          response.rola.id.toUpperCase() ===
          '4B8E07B8-3895-4E98-8D5A-13A4ED4017F4'
        ) {
          this.router.navigate(['/nullPermission']);
        }
        if (
          response.rola.id.toUpperCase() ===
          '187CE7AB-101D-450F-8503-BE95A28B5854'
        ) {
          this.router.navigate(['/administration']);
        }

        return response;
      });
  }

  register(
    login: string,
    password: string,
    email: string,
    imieNazwisko: string,
    school:Guid
  ): any {
    const request = new RegistrationRequest();
    request.login = login;
    request.imieNazwisko = imieNazwisko;
    request.email = email;
    request.password = password;
    request.school = school;

    return this.http
      .post<any>(AUTH_API + '/register', request, httpOptions)
      .subscribe((data) => {
        this.tokenStorageService.saveUser(data);
        this.router.navigate(['/register']);
      });
  }
}
