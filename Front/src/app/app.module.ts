import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { BoardAdminComponent } from './board-admin/board-admin.component';
import { BoardTeacherComponent } from './board-teacher/board-teacher.component';
import { BoardStudentComponent } from './board-student/board-student.component';
import { RegisterComponent } from './register/register.component';
import { BoardNullPermissionComponent } from './board-null-permission/board-null-permission.component';
import { BoardAdministrationComponent } from './board-administration/board-administration.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarAdminComponent } from './board-admin/nav-bar/nav-bar.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { LayoutModule } from '@angular/cdk/layout';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatExpansionModule } from '@angular/material/expansion';
import { NewSchoolComponent } from './board-admin/new-school/new-school.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { NavBarComponent } from './board-administration/nav-bar/nav-bar.component';
import { NewGroupComponent } from './board-administration/new-group/new-group.component';
import { NewSubjectComponent } from './board-administration/new-subject/new-subject.component';
import { ShowSubjectComponent } from './board-administration/show-subject/show-subject.component';
import { ChangeRoleComponent } from './board-administration/change-role/change-role.component';
import { MatRadioModule } from '@angular/material/radio';
import { ShowGroupComponent } from './board-administration/show-group/show-group.component';
import { NewLessonComponent } from './board-administration/show-subject/new-lesson/new-lesson.component';
import { ShowLessonComponent } from './board-teacher/show-lesson/show-lesson.component';
import {ShowLessonStudComponent}from './board-student/show-lesson/show-lesson.component';
import { NewClassesComponent } from './board-teacher/show-lesson/new-classes/new-classes.component';
import { MatNativeDateModule } from '@angular/material/core';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { ShowFilesComponent } from './board-teacher/show-lesson/show-files/show-files.component';
import { NewFilesComponent } from './board-teacher/show-lesson/new-files/new-files.component';
import { NavbarComponent } from './board-student/navbar/navbar.component';
import { ShowHistoryComponent } from './board-teacher/show-lesson/show-files/show-history/show-history.component';
import { ShowLessonFileComponent } from './board-student/show-lesson/show-lesson-file/show-lesson-file.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    BoardAdminComponent,
    BoardTeacherComponent,
    BoardStudentComponent,
    RegisterComponent,
    BoardNullPermissionComponent,
    BoardAdministrationComponent,
    NavBarAdminComponent,
    NewSchoolComponent,
    NavBarComponent,
    NewGroupComponent,
    NewSubjectComponent,
    ShowSubjectComponent,
    ChangeRoleComponent,
    ShowGroupComponent,
    NewLessonComponent,
    ShowLessonComponent,
    NewClassesComponent,
    ShowFilesComponent,
    NewFilesComponent,
    NavbarComponent,
    ShowHistoryComponent,
    ShowLessonStudComponent,
    ShowLessonFileComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    CommonModule,
    MatSelectModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatMenuModule,
    MatCheckboxModule,
    MatTabsModule,
    MatTableModule,
    LayoutModule,
    MatSidenavModule,
    MatListModule,
    MatPaginatorModule,
    MatSortModule,
    MatExpansionModule,
    MatSnackBarModule,
    MatDialogModule,
    FormsModule,
    MatRadioModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatDatepickerModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
