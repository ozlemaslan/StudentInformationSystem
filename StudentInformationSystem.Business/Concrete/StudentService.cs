using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformationSystem.Business.Concrete
{
    public class StudentService :IStudentService
    {
        IStudentDAL _studentDAL;

        public StudentService(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        public bool Add(Student entity)
        {
            return _studentDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Student student = _studentDAL.Get(a => a.Id == entityID);
            return _studentDAL.Delete(student) > 0;
        }

        public List<Student> GetAll()
        {
            return _studentDAL.GetAll().ToList();
        }

        public Student GetByID(int entityID)
        {
            return _studentDAL.Get(a => a.Id == entityID);
        }

        public bool Update(Student entity)
        {
            return _studentDAL.Update(entity) > 0;
        }
    }
}
