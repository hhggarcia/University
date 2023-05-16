// 1. using to work EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityAPI.DataAccess;
using UniversityAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// 2. Connection BD with SQl Server
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();

// 4 add services Scope, Transient, Single
AddScoped();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5 HABILITAR CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


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

// 6 tell app user CORS

app.UseCors("CorsPolicy");

app.Run();

void AddScoped()
{
    builder.Services.AddScoped<IServices, Services>();
    builder.Services.AddScoped<IStudentServices, StudentServices>();
    builder.Services.AddScoped<ICourseServices, CourseServices>();
    builder.Services.AddScoped<IChapterServices, ChapterServices>();
    builder.Services.AddScoped<ICategoryServices, CategoryServices>();

}