import { Injectable } from "@angular/core";
import { CanActivate,Router, CanLoad } from "@angular/router";
import {TokenStorageService}from "../../_services/token-storage.service";

@Injectable({ providedIn: 'root' })
export class TeacherGuard implements CanActivate,CanLoad {
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
    if(this.tokenStorageService.getRoleUser()?.toUpperCase()==='BC01F1AC-2389-4CFD-9D68-CA28FCB72C2F'){
      return true;
    } 
    return false;
  }
}