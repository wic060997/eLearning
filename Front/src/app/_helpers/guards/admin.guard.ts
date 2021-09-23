import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  CanLoad,
} from '@angular/router';
import { TokenStorageService } from '../../_services/token-storage.service';

@Injectable({ providedIn: 'root' })
export class AdminGuard implements CanActivate,CanLoad {
  constructor(
    private router: Router,
    private tokenStorageService: TokenStorageService
  ) {}

  canActivate() {
    return this.canLoad();
  }

  canLoad(){
    let user = this.tokenStorageService.getUser();
    if(!user){
      this.router.navigate(['/']);
    }
    if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='AC634082-8D93-4C54-B144-967FCDE35DF9'){
      return true;
    } 
    return false;
  }
}
