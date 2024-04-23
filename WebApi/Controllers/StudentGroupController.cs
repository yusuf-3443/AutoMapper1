using Domain.DTOs.StudentGroupDTO;
using Domain.Responses;
using Infrastructure.Services.StudentGroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/StudentGroup")]
[ApiController]
public class StudentGroupController(IStudentGroupService service):ControllerBase
{
    
    [HttpGet("Get-StudentGroup")]
    public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroups()
    {
        return await service.GetStudentGroups();
    }
    [HttpGet("studentGroup:int")]
    public async Task<Response<GetStudentGroupDto>> GetStudentGroupById(int studentGroup)
    {
        return await service.GetStudentGroupById(studentGroup);
    }

    [HttpPost("Add-StudentGroup")]
    public async Task<Response<string>> AddStudentGroup(AddStudentGroupDto add)
    {
        return await service.AddStudentGroup(add);
    }

    [HttpPut("Update-StudentGroup")]
    public async Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto update)
    {
        return await service.UpdateStudentGroup(update);
    }
    [HttpDelete("studentGroupId:int")]
    public async Task<Response<bool>> DeleteStudentGroup(int studentGroupId)
    {
        return await service.DeleteStudentGroup(studentGroupId);
    }
}