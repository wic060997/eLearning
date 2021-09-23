import { Injectable } from "@angular/core";
import { CanActivate,Router,ActivatedRouteSnapshot,RouterStateSnapshot } from "@angular/router";
import {TokenStorageService}from "../../_services/token-storage.service";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private tokenStorageService: TokenStorageService
  ) {}

  canActivate() {
    const user = this.tokenStorageService.getUser();
    if (user) {
        if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='AC634082-8D93-4C54-B144-967FCDE35DF9'){
          this.router.navigate(['/admin']);
        }
        if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='75944EBD-854D-4ACE-B991-9471E98C9233'){
          this.router.navigate(['/student']);
        }
        if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='BC01F1AC-2389-4CFD-9D68-CA28FCB72C2F'){
          this.router.navigate(['/teacher']);
        }
        if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='4B8E07B8-3895-4E98-8D5A-13A4ED4017F4'){
          this.router.navigate(['/nullPermission']);
        }
        if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='187CE7AB-101D-450F-8503-BE95A28B5854'){
          this.router.navigate(['/administration']);
        }
    }

    return true;
  }
}
