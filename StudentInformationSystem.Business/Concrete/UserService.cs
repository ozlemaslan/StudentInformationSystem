using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Data.DTOS;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformationSystem.Business.Concrete
{
    public class UserService :IUserService
    {

        IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool Add(User entity)
        {
            return _userDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            User user = _userDAL.Get(a => a.Id == entityID);
            return _userDAL.Delete(user) > 0;
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll().ToList();
        }

        public User GetByID(int entityID)
        {
            return _userDAL.Get(a => a.Id == entityID);
        }

        public bool Update(User entity)
        {
            return _userDAL.Update(entity) > 0;
        }

        public User GetByEmail(string email)
        {
            return _userDAL.Get(u => u.Email == email);
        }

        public bool UserExists(string email)
        {
            if (GetByEmail(email) != null)
            {
                return false;
            }
            return true;
        }
        public User Register(UserDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userDAL.Add(user);
            return user;
        }

        public User Login(UserDto userForLoginDto)
        {
            var userToCheck = GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                throw new Exception ("Kullanıcı bulunamadı");
            }

            if (!VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new Exception("Parola hatası");
            }

            return userToCheck;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != passwordHash[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
