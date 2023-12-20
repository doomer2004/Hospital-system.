using HospitalSystem.Common.DTO;

namespace HospitalSystem.BLL;

public interface IUserService
{
    Task<bool> MakeAdminAsync(MakeAdminDTO dto);
}