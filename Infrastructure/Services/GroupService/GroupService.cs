using System.Net;
using AutoMapper;
using Domain.DTOs.GroupDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext _context, IMapper _mapper) : IGroupService
{
    public async Task<Response<string>> AddGroup(AddGroupDto add)
    {
        try
        {
            var mapped = _mapper.Map<Group>(add);
            await _context.Groups.AddAsync(mapped);

            await _context.SaveChangesAsync();
            if(mapped != null) return new Response<string>("Added Successfully");

            return new Response<string>(HttpStatusCode.BadRequest,"Failed to add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    

    public async Task<Response<GetGroupDto>> GetGroupById(int id)
    {
    try
    {
        var result = await _context.Groups.FindAsync(id);
        if(result == null)
        {
            return new Response<GetGroupDto>(HttpStatusCode.BadRequest,"Not Found!");
        }else
        {
            return new Response<GetGroupDto>(_mapper.Map<GetGroupDto>(result));
        }

    }
    catch (System.Exception e)
    {
        return new Response<GetGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        } 
    }

    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        try
        {
            var result = await _context.Groups.ToListAsync();
            if(result != null)
            {
                return new Response<List<GetGroupDto>>(_mapper.Map<List<GetGroupDto>>(result));
            } 

            return new Response<List<GetGroupDto>>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateGroup(UpdateGroupDto update)
    {
        try
        {
            var result = await _context.Groups.FindAsync(update.Id);
            if(result == null)
            {
                return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");
            }

            _mapper.Map(update,result);
            await _context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Yet Updated!");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteGroup(int id)
    {
        try
        {
            var result = await _context.Groups.FindAsync(id);
            if(result == null)
            {
                return new Response<bool>(HttpStatusCode.NotFound,"Error");
            }
            _context.Groups.Remove(result);
            await _context.SaveChangesAsync();
            return new Response<bool>( HttpStatusCode.OK,"Deleted");

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}