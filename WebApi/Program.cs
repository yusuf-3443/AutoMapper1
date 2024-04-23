using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.CourseService;
using Infrastructure.Services.MentorGroupService;
using Infrastructure.Services.MentorService;
using Infrastructure.Services.StudentGroupService;
using Infrastructure.Services.StudentService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IMentorService,MentorService>();
builder.Services.AddScoped<GroupService,GroupService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IStudentGroupService,StudentGroupService>();
builder.Services.AddScoped<IMentorGroupService,MentorGroupService>();

var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(x => x.UseNpgsql(connection));


builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


