import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { AuthenticateResponse } from '../_models/authenticate_response';

const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root',
})
export class TokenStorageService {
  constructor() {}

  signOut(): void {
    window.sessionStorage.clear();
  }

  public getToken(): string | null {
    const session = localStorage.getItem(USER_KEY);
    if (session !== null) {
      const user = JSON.parse(session);
      return user.token;
    }
    return null;
  }

  public saveUser(user: AuthenticateResponse): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): AuthenticateResponse | null{
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return null;
  }

  public getSchool(): Guid | null{
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user).school.id;
    }

    return null;
  }

  public getRoleUser():string|null{
    const user = this.getUser();
    if (user) {
      return user.rola.id.toString();
    }

    return null;
  }
}
