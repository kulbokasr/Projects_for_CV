import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import School from 'src/app/models/school.model';
import Student from 'src/app/models/student.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent implements OnInit {
  @Input() studentsInput : Student[] = []; 
  @Output() removeStudentEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  public removeStudent(studentId : number){
    this.removeStudentEvent.emit(studentId)
  }

}
