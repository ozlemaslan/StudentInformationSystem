using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Business.Concrete;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDAL>().As<IUserDAL>().SingleInstance();

            builder.RegisterType<CourseService>().As<ICourseService>().SingleInstance();
            builder.RegisterType<CourseDAL>().As<ICourseDAL>().SingleInstance();

            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<TeacherDAL>().As<ITeacherDAL>();

            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<StudentDAL>().As<IStudentDAL>();

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

          


        }
    }
}
