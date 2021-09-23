import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from './../_services/auth.service'
import { TokenStorageService} from './../_services/token-storage.service'


@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  returnUrl?: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private tokenStorageService: TokenStorageService
  ) {
    if(this.tokenStorageService.getUser()){
      this.router.navigate(['/panel']);
    }
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() {
    return this.loginForm?.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.loginForm?.invalid) {
      return;
    }

    this.authService.login(this.f?.username.value, this.f?.password.value);
  }

  Register(){
    this.router.navigate(['/register']);
  }
}
