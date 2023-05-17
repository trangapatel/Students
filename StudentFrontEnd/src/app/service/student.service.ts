import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  url ="https://localhost:7082/api/data"
  constructor(private http:HttpClient) { }

  getAllStudents(){
    return this.http.get(`${this.url}`)
     }
  

}
