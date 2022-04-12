import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import StudentCreate from '../models/student-create.model';
import Student from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpClient: HttpClient) { }

  public getAll() : Observable<Student[]> {
    return this.httpClient.get<Student[]>('https://localhost:44304/Student')
  }
  public create(studentCreate : StudentCreate) : Observable<Student> {
    return this.httpClient.post<Student>('https://localhost:44304/Student', studentCreate)
  }
  public delete(id : number) : Observable<Student> {
    return this.httpClient.delete<Student>('https://localhost:44304/Student/'+id)
  }
}
