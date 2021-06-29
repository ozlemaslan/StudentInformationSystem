using StudentInformationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Model
{
    public class Student :BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
