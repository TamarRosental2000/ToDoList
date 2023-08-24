using Logic.Utils;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSingleton<UnitOfWork>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<TaskItemRepository>();
builder.Services.AddSingleton<TaskQuery>();
builder.Services.AddSingleton<UserQuery>();
builder.Services.AddSingleton<ValidateRequest>();


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
