using StudentInformationSystem.Core.DataAccess.EntityFramework;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Data.Concrete
{
    public class UserDAL :EFRepositoryBase<User,StudentContext>,IUserDAL
    {
    }
}
