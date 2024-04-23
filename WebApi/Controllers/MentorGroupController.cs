using Domain.DTOs.MentorGroupDTO;
using Domain.Responses;
using Infrastructure.Services.MentorGroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Mentor")]
[ApiController]
public class MentorGroupController(IMentorGroupService service):ControllerBase
{


    [HttpGet("Get-MentorGroups")]
    public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroups()
    {
        return await service.GetMentorGroups();
    }
    [HttpGet("mentorGroupId:int")]
    public async Task<Response<GetMentorGroupDto>> GetMentorGroupById(int mentorGroupId)
    {
        return await service.GetMentorGroupById(mentorGroupId);
    }

    [HttpPost("Add-MentorGroup")]
    public async Task<Response<string>> AddMentorGroup(AddMentorGroupDto add)
    {
        return await service.AddMentorGroup(add);
    }

    [HttpPut("Update-MentorGroup")]
    public async Task<Response<string>> UpdateMentorGroup(UpdateMentorGroupDto update)
    {
        return await service.UpdateMentorGroup(update);
    }
    [HttpDelete("mentorGroupId:int")]
    public async Task<Response<bool>> DeleteMentorGroup(int mentorGroupId)
    {
        return await service.DeleteMentorGroup(mentorGroupId);
    }
}