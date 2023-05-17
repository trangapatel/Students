using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Model
{
    
    public class StudentModel
    {
        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hobbies { get; set; }
    }
}
