using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infrastructure.Security
{
    public class BCryptAlgorithme
    {
        public string HashPassword(string password)=>BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}
