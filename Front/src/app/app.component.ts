import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TokenStorageService } from './_services/token-storage.service'
import { AuthenticateResponse } from './_models/authenticate_response';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent implements OnInit {
  title = 'Front';
  currentUser!: AuthenticateResponse;

  constructor(
    private router: Router,
    private tokenStorageService: TokenStorageService
  ) {}

  ngOnInit(): void {
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.rola.id.toString() === '24B69BA1-88CB-48A6-837E-8D4D89DA4B26';
  }

  get isStudent() {
    return this.currentUser && this.currentUser.rola.id.toString() === 'C968DE6F-6D9D-43F3-AF64-65484C86BEC3';
  }

  get isTeacher() {
    return this.currentUser && this.currentUser.rola.id.toString() === 'C8A3AA27-85A7-4B2C-91AA-CC9B786C3A4A';
  }

  logout() {
    this.tokenStorageService.signOut();
    this.router.navigate(['/login']);
  }
}