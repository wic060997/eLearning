import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  CanLoad,
} from '@angular/router';
import { TokenStorageService } from '../../_services/token-storage.service';

@Injectable({ providedIn: 'root' })
export class NullPermissionGuard implements CanActivate,CanLoad {
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
    if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='4B8E07B8-3895-4E98-8D5A-13A4ED4017F4'){
      return true;
    } 
    return false;
  }
}
