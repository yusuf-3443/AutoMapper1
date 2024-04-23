using Domain.DTOs.StudentDTO;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.StudentService;

public interface IStudentService
{
    Task<Response<List<GetStudentDto>>> GetStudents();
    Task<Response<GetStudentDto>> GetStudentById(int id);
    Task<Response<string>> AddStudent(AddStudentDto student);
    Task<Response<string>> UpdateStudent(UpdateStudentDto student);
    Task<Response<bool>> DeleteStudent(int id);

}