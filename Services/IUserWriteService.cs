using Learn_Net.DTOs;
using Learn_Net.Models;

namespace Learn_Net.Services
{
    public interface IUserWriteService
    {
        Task<UserWrite> SubmitAsync(SubmitWriteRequest request);
    }
}
