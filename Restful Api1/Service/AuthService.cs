using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restful_Api1.Dto;
using Restful_Api1.Models;


namespace Restful_Api1.Service
{

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return false;

            var user = new User { Username = dto.Username };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(
                user, user.PasswordHash, dto.Password
            );

            if (result == PasswordVerificationResult.Failed)
                return null;

            return _tokenService.CreateToken(user);
        }
    }

}

