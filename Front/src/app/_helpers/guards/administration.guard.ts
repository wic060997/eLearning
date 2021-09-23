import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  CanLoad,
} from '@angular/router';
import { TokenStorageService } from '../../_services/token-storage.service';

@Injectable({ providedIn: 'root' })
export class AdministrationGuard implements CanActivate,CanLoad {
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
    if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='187CE7AB-101D-450F-8503-BE95A28B5854'){
      return true;
    } 
    return false;
  }
}
