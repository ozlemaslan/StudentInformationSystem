using StudentInformationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Model
{
    public class Teacher :BaseModel
    {
        public string Name { get; set; }
        public string Education { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

    }
}
