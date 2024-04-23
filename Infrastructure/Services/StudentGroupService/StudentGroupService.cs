using System.Net;
using AutoMapper;
using Domain.DTOs.StudentGroupDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentGroupService;

public class StudentGroupService(DataContext context, IMapper mapper) : IStudentGroupService
{
    public async Task<Response<string>> AddStudentGroup(AddStudentGroupDto add)
    {
        try
        {
            
        var mapped = mapper.Map<StudentGroup>(add);
        await context.StudentGroups.AddAsync(mapped);
        await context.SaveChangesAsync();
            if(mapped != null)return new Response<string>("Added Successfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add !");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroups()
    {
        try
        {
            var result = await context.StudentGroups.ToListAsync();
            if(result != null) return new Response<List<GetStudentGroupDto>>(mapper.Map<List<GetStudentGroupDto>>(result));
            
            return new Response<List<GetStudentGroupDto>>(HttpStatusCode.BadRequest,"Error");

        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetStudentGroupDto>> GetStudentGroupById(int id)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(id);
            if (result == null)
            {
                return new Response<GetStudentGroupDto>(HttpStatusCode.BadRequest,"Not Found!");
            }else
            {
                return new Response<GetStudentGroupDto>(mapper.Map<GetStudentGroupDto>(result));
            }
        }
        catch (System.Exception e)
        {
            return new Response<GetStudentGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto update)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(update.Id);
            if (result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");

            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>("Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

        public async Task<Response<bool>> DeleteStudentGroup(int id)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(id);
            if (result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found ",false);
            }
            context.StudentGroups.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.Accepted,"Deleted",true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}