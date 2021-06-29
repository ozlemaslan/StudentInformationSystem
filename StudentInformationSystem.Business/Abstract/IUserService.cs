using StudentInformationSystem.Data.DTOS;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Business.Abstract
{
    public interface IUserService :IBaseService<User>
    {
        User GetByEmail(string email);
        User Register(UserDto userForRegisterDto);
        User Login(UserDto userForLoginDto);
        bool UserExists(string email);
    }
}
