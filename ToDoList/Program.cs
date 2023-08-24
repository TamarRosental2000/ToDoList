//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using NHibernate.Engine;
//using ToDoList.Api;

//namespace Api
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateWebHostBuilder(args).Build().Run();
//        }

//        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
//        {
//            return WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>();
//        }
//    }
//}

using Logic.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.ExceptionHandling;
using ToDoList.Db.Context;
using ToDoList.Db.Command;
using ToDoList.Db.Query;
using ToDoList.Api.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoListDBContext>();
var dbContextOptionsBuilder = new DbContextOptionsBuilder<ToDoListDBContext>();
dbContextOptionsBuilder.UseSqlServer("DataSource=ToDoList.Db;Cache=Shared");
builder.Services.AddMvc();

builder.Services.AddSingleton<SessionFactory>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TaskItemRepository>();
builder.Services.AddScoped<TaskQuery>();
builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<ValidateRequest>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseCors("AllowAll");
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.Run();
