import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticateResponse } from '../_models/authenticate_response';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  currentUser!: AuthenticateResponse;


  constructor(private router: Router,
    private tokenStorageService: TokenStorageService) { }

  ngOnInit(): void {
  }

  get isAdmin() {
    return this.currentUser && 
      this.currentUser.rola.id.toString() === 'AC634082-8D93-4C54-B144-967FCDE35DF9';
  }

  get isStudent() {
    return this.currentUser && 
      this.currentUser.rola.id.toString() === '75944EBD-854D-4ACE-B991-9471E98C9233';
  }

  get isTeacher() {
    return this.currentUser && 
      this.currentUser.rola.id.toString() === 'BC01F1AC-2389-4CFD-9D68-CA28FCB72C2F';
  }
  get isAdministration() {
    return this.currentUser && 
      this.currentUser.rola.id.toString() === '187CE7AB-101D-450F-8503-BE95A28B5854';
  }
  get isNullPermission() {
    return this.currentUser && 
      this.currentUser.rola.id.toString() === '4B8E07B8-3895-4E98-8D5A-13A4ED4017F4';
  }

login(){
  this.router.navigate(['/login']);
}

  logout() {
    this.tokenStorageService.signOut();
    this.router.navigate(['/login']);
  }

}
