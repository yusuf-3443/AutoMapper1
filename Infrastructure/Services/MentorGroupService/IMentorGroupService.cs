using Domain.DTOs.CourseDTO;
using Domain.DTOs.MentorGroupDTO;
using Domain.Responses;

namespace Infrastructure.Services.MentorGroupService;

public interface IMentorGroupService
{
    Task<Response<List<GetMentorGroupDto>>> GetMentorGroups();
    Task<Response<GetMentorGroupDto>> GetMentorGroupById(int id);
    Task<Response<string>> AddMentorGroup(AddMentorGroupDto mentorGroup);
    Task<Response<string>> UpdateMentorGroup(UpdateMentorGroupDto mentorGroup);
    Task<Response<bool>> DeleteMentorGroup(int id);
}