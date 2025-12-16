using Restful_Api1.Dto;

namespace Restful_Api1.Service
{
    public interface IAuthService
    {
        
            Task<bool> RegisterAsync(RegisterDto dto);
            Task<string?> LoginAsync(LoginDto dto);
        

    }
}
