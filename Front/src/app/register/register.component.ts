import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { School } from '../_models/school';
import { AuthService } from '../_services/auth.service';
import { SchoolService } from '../_services/school.service';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  public schools!: School[];
  school!: School;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private tokenStorageService: TokenStorageService,
    private schoolService: SchoolService
  ) {
    if (this.tokenStorageService.getUser()) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.loadSchool();

    this.registerForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
      imieNazwisko: ['', Validators.required],
    });
  }

  get f() {
    return this.registerForm?.controls;
  }

  loadSchool() {
    this.schoolService.getAll().subscribe((data) => {
      this.schools = data;
    });
  }

  onSubmit() {
    if (this.registerForm?.invalid) {
      return;
    }

    this.authService.register(
      this.f?.login.value,
      this.f?.password.value,
      this.f?.email.value,
      this.f?.imieNazwisko.value,
      this.school.id
    );
  }

  Zaloguj() {
    this.router.navigate(['/login']);
  }
}
