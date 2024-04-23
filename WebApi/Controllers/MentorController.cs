using Domain.DTOs.MentorDto;
using Domain.Responses;
using Infrastructure.Services.MentorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Mentor")]
[ApiController]
public class MentorController(IMentorService service):ControllerBase
{
    [HttpGet("Get-Mentors")]
    public async Task<Response<List<GetMentorDto>>> GetMentors()
    {
        return await service.GetMentors();
    }
    [HttpGet("mentorId:int")]
    public async Task<Response<GetMentorDto>> GetMentorById(int mentorId)
    {
        return await service.GetMentorById(mentorId);
    }

    [HttpPost("Add-Mentor")]
    public async Task<Response<string>> AddMentor(AddMentorDto add)
    {
        return await service.AddMentor(add);
    }

    [HttpPut("Update-Mentor")]
    public async Task<Response<string>> UpdateMentor(UpdateMentorDto update)
    {
        return await service.UpdateMentor(update);
    }
    [HttpDelete("mentorId:int")]
    public async Task<Response<bool>> DeleteMentor(int mentorId)
    {
        return await service.DeleteMentor(mentorId);
    }
}