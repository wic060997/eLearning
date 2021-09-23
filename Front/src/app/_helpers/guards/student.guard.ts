import { Injectable } from "@angular/core";
import { CanActivate,Router, CanLoad } from "@angular/router";
import {TokenStorageService}from "../../_services/token-storage.service";

@Injectable({ providedIn: 'root' })
export class StudentGuard implements CanActivate,CanLoad {
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
    if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='75944EBD-854D-4ACE-B991-9471E98C9233'){
      return true;
    } 
    return false;
  }
}