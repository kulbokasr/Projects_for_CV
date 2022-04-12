import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import SchoolCreate from '../models/school-create.model';
import SchoolEdit from '../models/school-edit.model';
import School from '../models/school.model';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  constructor(private httpClient: HttpClient) { }

  public getAll() : Observable<School[]> {
    return this.httpClient.get<School[]>('https://localhost:44304/School')
  }
  public create(schoolCreate : SchoolCreate) : Observable<School> {
    return this.httpClient.post<School>('https://localhost:44304/School', schoolCreate)
  }
  public delete(id : number) : Observable<School> {
    return this.httpClient.delete<School>('https://localhost:44304/School/'+id)
  }
  public update(id : number, schoolEdit : SchoolEdit) : Observable<School> {
    return this.httpClient.put<School>('https://localhost:44304/School/'+id, schoolEdit)
  }

}
