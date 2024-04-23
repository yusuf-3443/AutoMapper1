using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class StudentService:IStudentService
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public StudentService(DataContext _context,IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }

     public async Task<Response<string>> AddStudent(AddStudentDto add)
    {
        try
        {
        var mapped = mapper.Map<Student>(add);
        await context.Students.AddAsync(mapped);
        await context.SaveChangesAsync();
        if(mapped != null)return new Response<string>("Added Successfully!");
        return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add !"); 
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }

    }

    public async Task<Response<GetStudentDto>> GetStudentById(int id)
    {
        try
        {
            var result = await context.Students.FindAsync(id);
            if(result == null) return new Response<GetStudentDto>(HttpStatusCode.BadRequest,"Not Found!");

            return new Response<GetStudentDto>(mapper.Map<GetStudentDto>(result));
            }
        catch (System.Exception e)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetStudentDto>>> GetStudents()
    {
        try
        {
            var result = await context.Students.ToListAsync();
            if(result != null) return new Response<List<GetStudentDto>>(mapper.Map<List<GetStudentDto>>(result));

            return new Response<List<GetStudentDto>>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudent(UpdateStudentDto update)
    {
        try
        {
            var result = await context.Students.FindAsync(update.Id);
            if(result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found");

            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>("Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    
    public async Task<Response<bool>> DeleteStudent(int id)
    {
        try
        {
            var result = await context.Students.FindAsync(id);
            if(result == null) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found!");

            context.Students.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
}