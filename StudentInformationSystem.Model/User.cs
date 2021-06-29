using StudentInformationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Model
{
    public class User : BaseModel
    {
        public User()
        {
            Courses = new HashSet<Course>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public bool IsAdmin { get; set; } = false;
        public virtual ICollection<Course> Courses { get; set; }

    }
}
