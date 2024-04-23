using System.Net;
using AutoMapper;
using Domain.DTOs.MentorDto;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorService;

public class MentorService(DataContext _context, IMapper _mapper) : IMentorService
{
    public async Task<Response<string>> AddMentor(AddMentorDto add)
    {
        try
        {
            var mapped = _mapper.Map<Mentor>(add);
            await _context.Mentors.AddAsync(mapped);
            await _context.SaveChangesAsync();
            if(mapped != null) return new Response<string>("Added Success");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed To Add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetMentorDto>> GetMentorById(int id)
    {
        try
        {
            
        var result = await _context.Mentors.FindAsync(id);
        if(result == null) return new Response<GetMentorDto>(HttpStatusCode.BadRequest,"Not Found!");

        return new Response<GetMentorDto>(_mapper.Map<GetMentorDto>(result));
        }
        catch (System.Exception e)
        {
            return new Response<GetMentorDto>(HttpStatusCode.InternalServerError,e.Message);
        }

    }

    public async Task<Response<List<GetMentorDto>>> GetMentors()
    {
        try
        {
            var result = await _context.Mentors.ToListAsync();
            if(result == null) return new Response<List<GetMentorDto>>(HttpStatusCode.BadRequest,"Error");

            return new Response<List<GetMentorDto>>(_mapper.Map<List<GetMentorDto>>(result));
        }

        catch (System.Exception e)
        {
            return new Response<List<GetMentorDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentor(UpdateMentorDto update)
    {
        try
        {
            var result = await _context.Mentors.FindAsync(update.Id);
            if(result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");
            
            _mapper.Map(update,result);
            await _context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.Accepted,"Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    
    public async Task<Response<bool>> DeleteMentor(int id)
    {
        try
        {
            var result = await _context.StudentGroups.FindAsync(id);
            if (result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found",false);
            }
            _context.StudentGroups.Remove(result);
            await _context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.Accepted,"Deleted",true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
}