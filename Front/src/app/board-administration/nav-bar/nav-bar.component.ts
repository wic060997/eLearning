import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticateResponse } from 'src/app/_models/authenticate_response';
import { User } from 'src/app/_models/user';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent implements OnInit {
  currentUser!: AuthenticateResponse;
  user!:User;

  constructor(
    private router: Router,
    private tokenStorageService: TokenStorageService,
    private userService: UserService,
  ) {}

  ngOnInit(): void {
    let user = this.tokenStorageService.getUser();
    if (user != null) {
      this.currentUser = user;
      this.userService.getUserById(user.id)
      .subscribe((data) => {
        this.user = data;
      });
    }
  }

  logout() {
    this.tokenStorageService.signOut();
    this.router.navigate(['/login']);
  }
}
