using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Core.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsActive = true;
            CreateTime = DateTime.Now;
            ModificationTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsActive { get; set; }
    }
}
