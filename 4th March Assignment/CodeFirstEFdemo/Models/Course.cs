using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFdemo.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel level { get; set; }
        public List<Students> Students { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
    public enum CourseLevel
    {
        Beginner=1,
        Intermediate=2,
        Advanced=3
    }
}
