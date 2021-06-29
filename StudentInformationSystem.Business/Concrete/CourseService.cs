using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformationSystem.Business.Concrete
{
    public class CourseService : ICourseService
    {
        ICourseDAL _courseDAL;

        public CourseService(ICourseDAL courseDAL)
        {
            _courseDAL = courseDAL;
        }

        public bool Add(Course entity)
        {
            return _courseDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Course course = _courseDAL.Get(a => a.Id == entityID);
            return _courseDAL.Delete(course) > 0;
        }

        public List<Course> GetAll()
        {
            return _courseDAL.GetAll().ToList();
        }

        public Course GetByID(int entityID)
        {
            return _courseDAL.Get(a => a.Id == entityID);
        }

        public bool Update(Course entity)
        {
            return _courseDAL.Update(entity) > 0;
        }
    }
}
