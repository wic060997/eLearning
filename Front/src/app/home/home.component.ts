import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthenticateResponse } from '../_models/authenticate_response';
import { TokenStorageService } from './../_services/token-storage.service';

@Component({ templateUrl: 'home.component.html',
styleUrls: ['./home.component.scss'] })
export class HomeComponent {
  loading = false;
  currentUser!: AuthenticateResponse;

  constructor(
    private tokenStorageService: TokenStorageService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    const u = this.tokenStorageService.getUser();
    if(u!==null){
      this.currentUser = u;
    }
    
  }

  ngOnInit() {
    const u = this.tokenStorageService.getUser();
    if(u!==null){
      this.currentUser = u;
    }
  }

  Login(){
    this.router.navigate(['/login']);
  }
}
