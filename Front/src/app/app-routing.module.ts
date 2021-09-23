import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { AdminGuard } from './_helpers/guards/admin.guard';
import { AuthGuard } from './_helpers/guards/auth.guard';
import { StudentGuard } from './_helpers/guards/student.guard';
import { TeacherGuard } from './_helpers/guards/teacher.guard';
import { BoardAdminComponent } from './board-admin/board-admin.component';
import { BoardStudentComponent } from './board-student/board-student.component';
import { RegisterComponent } from './register/register.component';
import { BoardTeacherComponent } from './board-teacher/board-teacher.component';
import { Rola } from './_models/rola';
import { BoardNullPermissionComponent } from './board-null-permission/board-null-permission.component';
import { NullPermissionGuard } from './_helpers/guards/nullPermission.guard';
import { BoardAdministrationComponent } from './board-administration/board-administration.component';
import { AdministrationGuard } from './_helpers/guards/administration.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'admin',
    component: BoardAdminComponent,
    canActivate: [AdminGuard],
    canLoad: [AdminGuard]
  },
  {
    path: 'student',
    component: BoardStudentComponent,
    canActivate: [StudentGuard],
    canLoad: [StudentGuard]
  },
  {
    path: 'teacher',
    component: BoardTeacherComponent,
    canActivate: [TeacherGuard],
    canLoad: [TeacherGuard]
  },
  {
    path: 'nullPermission',
    component: BoardNullPermissionComponent,
    canActivate: [NullPermissionGuard],
    canLoad: [NullPermissionGuard]
  },
  {
    path: 'administration',
    component: BoardAdministrationComponent,
    canActivate: [AdministrationGuard],
    canLoad: [AdministrationGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'register',
    component: RegisterComponent,
    canActivate:[AuthGuard]
  },

  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
