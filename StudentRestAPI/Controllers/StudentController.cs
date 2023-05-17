using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRestAPI.Model;
using StudentRestAPI.Data;

namespace StudentRestAPI.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiContext _context;

        public StudentController(ApiContext context)
        {
            _context = context;
        }

        // Create
        [HttpPost]
        public JsonResult Create(Student student)
        {
           StudentModel student2= new StudentModel();
            student2.Name=student.Name;
            student2.Age = student.Age;

            string hobbies = "";
          
            for (int i = 0; i < student.Hobbies.Count; i++) {

                if (i == student.Hobbies.Count - 1)
                {
                    hobbies = hobbies + student.Hobbies[i];
                }
                else {
                    hobbies = hobbies + student.Hobbies[i]+"##";

                }
                
            }

            student2.Hobbies = hobbies;

            _context.StudentsModel.Add(student2);       
            _context.SaveChanges();
            return new JsonResult(Ok(student));

        }

        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            List<StudentModel> students2 = _context.StudentsModel.ToList();
            List<Student> students;

            if (students2.Count == 0) {
                var student1 = new Student
                {
                    Name = "Alice",
                    Age = 20,
                    Hobbies = new List<string>() { "reading", "swimming", "coding" }
                };

                var student2 = new Student
                {
                    Name = "Bob",
                    Age = 22,
                    Hobbies = new List<string>() { "painting", "dancing", "singing" }
                };

                Create(student1);
                Create(student2);

                return new JsonResult(Ok(new List<Student> {student1, student2 }));
            }

            students= new List<Student>();

            foreach (StudentModel student2 in students2) {

                Student student = new Student();
                student.Age = student2.Age;
                student.Name=student2.Name;                              

                string hobbiesString = student2.Hobbies;
                string[] hobs = hobbiesString.Split("##");
                List<String> hobbies = hobs.ToList();
                student.Hobbies = hobbies;
            
                students.Add(student);
            }

            return new JsonResult(Ok(students));

        }

    }
}
