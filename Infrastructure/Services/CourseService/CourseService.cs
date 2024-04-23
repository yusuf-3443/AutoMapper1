using System.Net;
using AutoMapper;
using Domain.DTOs.CourseDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CourseService;

public class CourseService(DataContext context, IMapper mapper) : ICourseService
{
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        try
        {
            var mapped = mapper.Map<Course>(add);
            await context.AddAsync(mapped);
            await context.SaveChangesAsync();
            if(mapped != null)return new Response<string>("Added Successfully");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<List<GetCourseDto>>> GetCourses()
    {
        try
        {
            var result = await context.Courses.ToListAsync();
            if(result != null) return new Response<List<GetCourseDto>>(mapper.Map<List<GetCourseDto>>(result));

            return new Response<List<GetCourseDto>>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetCourseDto>> GetCourseById(int id)
    {
        try
        {
            var result = await context.Courses.FindAsync(id);
            if (result == null)
            {
                return new Response<GetCourseDto>(HttpStatusCode.BadRequest,"Course Not Found!");
            }else
            {
                return new Response<GetCourseDto>(mapper.Map<GetCourseDto>(result));
            }
        }
        catch (System.Exception e)
        {
        return new Response<GetCourseDto>(HttpStatusCode.InternalServerError,e.Message);    
        }
    }

    public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        try
        {
            var result = await context.Courses.FindAsync(update.Id);
            if(result == null)
            {
                return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");
            }
            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    
    public async Task<Response<bool>> DeleteCourse(int id)
    {
        try
        {
            var result = await context.Courses.FindAsync(id);
            if(result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found ",false);
            }
            context.Courses.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.Accepted,"Deleted",true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
}