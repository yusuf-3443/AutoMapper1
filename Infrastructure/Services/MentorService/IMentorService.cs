using Domain.DTOs.MentorDto;
using Domain.DTOs.MentorGroupDTO;
using Domain.Responses;

namespace Infrastructure.Services.MentorService;

public interface IMentorService
{
    Task<Response<List<GetMentorDto>>> GetMentors();
    Task<Response<GetMentorDto>> GetMentorById(int id);
    Task<Response<string>> AddMentor(AddMentorDto mentor);
    Task<Response<string>> UpdateMentor(UpdateMentorDto mentor);
    Task<Response<bool>> DeleteMentor(int id);
}