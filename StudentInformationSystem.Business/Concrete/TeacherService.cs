using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformationSystem.Business.Concrete
{
    public class TeacherService : ITeacherService
    {
        ITeacherDAL _teacherDAL;

        public TeacherService(ITeacherDAL teacherDAL)
        {
            _teacherDAL = teacherDAL;
        }

        public bool Add(Teacher entity)
        {
            return _teacherDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Teacher teacher = _teacherDAL.Get(a => a.Id == entityID);
            return _teacherDAL.Delete(teacher) > 0;
        }

        public List<Teacher> GetAll()
        {
            return _teacherDAL.GetAll().ToList();
        }

        public Teacher GetByID(int entityID)
        {
            return _teacherDAL.Get(a => a.Id == entityID);
        }

        public bool Update(Teacher entity)
        {
            return _teacherDAL.Update(entity) > 0;
        }
    }
}
