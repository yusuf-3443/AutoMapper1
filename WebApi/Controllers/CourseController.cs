using Domain.DTOs.CourseDTO;
using Domain.Responses;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Course")]
[ApiController]
public class CourseController(ICourseService service):ControllerBase
{
    [HttpGet("Get-Courses")]
    public async Task<Response<List<GetCourseDto>>> GetCourses()
    {
        return await service.GetCourses();
    }

    [HttpGet("courseId:int")]
    public async Task<Response<GetCourseDto>> GetCourseById(int courseId)
    {
        return await service.GetCourseById(courseId);
    }

    [HttpPost("Add-Course")]
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        return await service.AddCourse(add);
    }
    [HttpPut("Update-Course")]
    public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        return await service.UpdateCourse(update);
    }

    [HttpDelete("courseId:int")]
    public async Task<Response<bool>> DeleteCourse(int courseId)
    {
        return await service.DeleteCourse(courseId);
    }
}