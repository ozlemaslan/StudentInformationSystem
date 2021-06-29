using StudentInformationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Model
{
    public class Course :BaseModel
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public int UserID { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
