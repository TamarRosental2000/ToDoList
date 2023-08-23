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
using ToDoList.Db.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoListDBContext>();
var dbContextOptionsBuilder = new DbContextOptionsBuilder<ToDoListDBContext>();
dbContextOptionsBuilder.UseSqlServer("DataSource=ToDoList.Db;Cache=Shared");

//builder.Services.AddSingleton(new SessionFactory("Server=.\\Sql;Database=ILTAMARR-LT1;Trusted_Connection=true;"));
//builder.Services.AddScoped<UnitOfWork>();


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
