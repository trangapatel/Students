import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentService } from 'src/app/service/student.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'StudentFrontEnd';
  students=[]
  
  ngOnInit(): void {
   

    this.studentService.getAllStudents().subscribe(
     (response:any) => {        
       console.log(response.value)       
       this.students =response.value

       this.students.forEach(function (student:any) {
       student['hobbies'] =  student['hobbies'].toString() 

    });
          
     }
    )
    
   }
 
 
  
  constructor(private studentService: StudentService){
   

  }


}
