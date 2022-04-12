import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-school-create',
  templateUrl: './school-create.component.html',
  styleUrls: ['./school-create.component.scss']
})
export class SchoolCreateComponent implements OnInit {
 
  @Output() schoolCreateEvent = new EventEmitter<string>();
  @Input() errorInput : any
  public schoolName : string = '';
  public hidden : boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  public createSchool(){
    this.schoolCreateEvent.emit(this.schoolName)
  }

}
