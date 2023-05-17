using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Model
{
    
    public class Student
    {
        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
        public List<String> Hobbies { get; set; }
    }
}
