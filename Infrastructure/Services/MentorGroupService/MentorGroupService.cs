using System.Net;
using AutoMapper;
using Domain.DTOs.MentorGroupDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorGroupService;

public class MentorGroupService(DataContext _context, IMapper _mapper) : IMentorGroupService
{
    public async Task<Response<string>> AddMentorGroup(AddMentorGroupDto add)
    {
        try
        {
        var mapped = _mapper.Map<MentorGroup>(add);
        await _context.AddRangeAsync(mapped);
        await _context.SaveChangesAsync();
        
        if(mapped != null)return new Response<string>("Added Successfully");
        return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);            
        }
    }

    public async Task<Response<GetMentorGroupDto>> GetMentorGroupById(int id)
    {
        try
        {
            
            var result = await _context.MentorGroups.FindAsync(id);
            if(result == null) return new Response<GetMentorGroupDto>(HttpStatusCode.BadRequest,"Not found");

            return new Response<GetMentorGroupDto>(_mapper.Map<GetMentorGroupDto>(result));
        }
        catch (System.Exception e)
        {
            return new Response<GetMentorGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroups()
    {
        try
        {
            var result = await _context.MentorGroups.ToListAsync();
            var res = _mapper.Map<List<GetMentorGroupDto>>(result);
            return new Response<List<GetMentorGroupDto>>(res);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetMentorGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorGroup(UpdateMentorGroupDto update)
    {
        try
        {
            var result = await _context.MentorGroups.FindAsync(update.Id);
            if(result == null)
            {
                return new Response<string>(HttpStatusCode.BadRequest,"Not Found");
            }
            _mapper.Map(update,result);
            await _context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Successfully");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
        public async Task<Response<bool>> DeleteMentorGroup(int id)
    {
        try
        {
            var result = await _context.MentorGroups.FindAsync(id);
            if(result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found",false);
            }
            _context.MentorGroups.Remove(result);
            await _context.SaveChangesAsync();
                        return new Response<bool>(HttpStatusCode.Accepted,"Successfully",true);

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}