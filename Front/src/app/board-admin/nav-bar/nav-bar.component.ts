import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticateResponse } from 'src/app/_models/authenticate_response';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-navbarAdmin',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarAdminComponent implements OnInit {
  currentUser!: AuthenticateResponse;

  constructor(
    private router: Router,
    private tokenStorageService: TokenStorageService
  ) {}

  ngOnInit(): void {
    let user = this.tokenStorageService.getUser();
    if (user != null) {
      this.currentUser = user;
    }
  }

  logout() {
    this.tokenStorageService.signOut();
    this.router.navigate(['/login']);
  }
}
