using StudentInformationSystem.Core.DataAccess;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Data.Abstract
{
    public interface ITeacherDAL :IRepository<Teacher>
    {
    }
}
