using Domain.DTOs.GroupDTO;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IGroupService
{
    Task<Response<List<GetGroupDto>>> GetGroups();
    Task<Response<GetGroupDto>> GetGroupById(int id);
    Task<Response<string>> AddGroup(AddGroupDto group);
    Task<Response<string>> UpdateGroup(UpdateGroupDto group);
    Task<Response<bool>> DeleteGroup(int id);
}