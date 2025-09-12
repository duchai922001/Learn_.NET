using Learn_Net.Models;

namespace Learn_Net.Utils
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
