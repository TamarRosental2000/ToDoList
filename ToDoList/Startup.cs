using Logic.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ExceptionHandling;
using ToDoList.Db.Context;

namespace ToDoList.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(new SessionFactory());
            services.AddScoped<UnitOfWork>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ToDoListDBContext>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ToDoListDBContext>();
            dbContextOptionsBuilder.UseSqlServer("DataSource=ToDoList.Db;Cache=Shared");

        }

        public void Configure(IApplicationBuilder app)
        { 
            //var app = builder.Build();
            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseMiddleware<ExceptionHandler>();
            app.UseMvc();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapControllers();


            app.UseCors("AllowAll");
            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

            //app.Run();

        }
    }
}
