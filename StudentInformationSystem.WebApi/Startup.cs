using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Data;
using Newtonsoft.Json;
using StudentInformationSystem.Business.Concrete;
using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Data.Concrete;

namespace StudentInformationSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddEntityFrameworkSqlServer().AddDbContext<StudentContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
//            services.AddControllers().AddNewtonsoftJson(options =>
//options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ICourseService, CourseService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ITeacherService, TeacherService>();
            //services.AddScoped<IUserDAL, UserDAL>();
            //services.AddScoped<ICourseDAL, CourseDAL>();
            //services.AddScoped<IStudentDAL, StudentDAL>();
            //services.AddScoped<ITeacherDAL, TeacherDAL>();

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
