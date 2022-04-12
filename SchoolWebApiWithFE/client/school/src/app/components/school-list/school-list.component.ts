import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import SchoolEdit from 'src/app/models/school-edit.model';
import School from 'src/app/models/school.model';
import Student from 'src/app/models/student.model';
import { SchoolService } from 'src/app/services/school.service';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.scss']
})
export class SchoolListComponent implements OnInit {

  @Input() schoolsInput : School[] = [];
  @Input() studentInput : Student[] = [];
  @Output() removeChoolEvent = new EventEmitter<number>();
  @Output() updateChoolEvent = new EventEmitter<number>();
  public idToEdit : number = NaN
  public updateName : string = ""
  constructor(private schoolService : SchoolService) { }


  ngOnInit(): void {
  }

  public removeSchool(schoolId: number){
    this.removeChoolEvent.emit(schoolId);
  }
  public updateSchool(schoolId: number){
    this.idToEdit = schoolId;
    var index = this.schoolsInput.findIndex(x=> x.id == schoolId);
    this.updateName = this.schoolsInput[index].name
  }

  public submitUpdatedName() : void {
    let schoolEdit : SchoolEdit = {
      name : this.updateName
    }
    this.schoolService.update(this.idToEdit, schoolEdit).subscribe()
    this.schoolsInput.forEach(x => { if(x.id == this.idToEdit) {x.name = this.updateName} })
    this.idToEdit = NaN
  }

}
