import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SchoolComponent } from './components/school/school.component';
import { SchoolListComponent } from './components/school-list/school-list.component';
import { SchoolCreateComponent } from './components/school-create/school-create.component';
import { StudentComponent } from './components/student/student.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { StudentCreateComponent } from './components/student-create/student-create.component';
import { MasterComponent } from './components/master/master.component';

@NgModule({
  declarations: [
    AppComponent,
    SchoolComponent,
    SchoolListComponent,
    SchoolCreateComponent,
    StudentComponent,
    StudentListComponent,
    StudentCreateComponent,
    MasterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
