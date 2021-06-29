using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Data
{
    public class StudentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MUG6E3FO;Initial Catalog=StudentDB;User=sa;Password=P@ssw0rd;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddUser(modelBuilder);
        }

        public StudentContext()
        {

        }
        public StudentContext(DbContextOptions<StudentContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        private void AddUser(ModelBuilder modelBuilder)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("12345", out passwordHash, out passwordSalt);

            modelBuilder.Entity<User>().HasData(
                            new User
                            {
                                Id=1,
                                Email = "admin@admin.com.tr",
                                FirstName = "admin",
                                LastName = "admin",
                                PasswordHash = passwordHash,
                                PasswordSalt = passwordSalt,
                                Status = true,
                                IsAdmin = true,
                                ModificationTime = DateTime.Now,
                            }); 
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
