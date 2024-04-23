using Domain.DTOs.StudentDTO;
using Domain.DTOs.StudentGroupDTO;
using Domain.Responses;

namespace Infrastructure.Services.StudentGroupService;

public interface IStudentGroupService
{
    Task<Response<List<GetStudentGroupDto>>> GetStudentGroups();
    Task<Response<GetStudentGroupDto>> GetStudentGroupById(int id);
    Task<Response<string>> AddStudentGroup(AddStudentGroupDto studentGroup);
    Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto studentGroup);
    Task<Response<bool>> DeleteStudentGroup(int id);
}