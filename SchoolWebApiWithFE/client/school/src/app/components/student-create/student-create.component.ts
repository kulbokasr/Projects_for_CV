import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import School from 'src/app/models/school.model';
import StudentCreate from 'src/app/models/student-create.model';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent implements OnInit {
  
  public studentCreate : StudentCreate = {
    name : '',
    schoolId : NaN
  }
  @Output() studentCreateEvent = new EventEmitter<StudentCreate>();
  @Input() schoolsInput : School[] = []; 
  @Input() schoolIdErrorInput : string = ""
  @Output() getSchoolsEvent = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }

  public createStudent(){
    this.studentCreateEvent.emit(this.studentCreate)
  }

  public getCurrentSchools(){
    this.getSchoolsEvent.emit()
  }
}
