using Domain.DTOs.GroupDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Group")]
[ApiController]
public class GroupController(IGroupService service):ControllerBase
{
    [HttpGet("Get-Groups")]
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        return await service.GetGroups();
    }

    [HttpGet("groupId:int")]
    public async Task<Response<GetGroupDto>> GetGroupById(int groupId)
    {
        return await service.GetGroupById(groupId);
    }
    [HttpPost("Add-Group")]
    public async Task<Response<string>> AddGroup(AddGroupDto add)
    {
        return await service.AddGroup(add);
    }

    [HttpPut("Update-Group")]
    public async Task<Response<string>> UpdateGroup(UpdateGroupDto update)
    {
        return await service.UpdateGroup(update);
    }

    [HttpDelete("groupId:int")]
    public async Task<Response<bool>> DeleteGroup(int groupId)
    {
        return await service.DeleteGroup(groupId);
    }
}