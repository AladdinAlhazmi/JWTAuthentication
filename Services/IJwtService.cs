using Microsoft.AspNetCore.Identity;
using JWTAuthentication.DTOs.Auth;
using JWTAuthentication.DTOs.Auth.Request;
using JWTAuthentication.DTOs.Auth.Response;

namespace JWTAuthentication.Services;

public interface IJwtService
{
    Task<AuthResult> GenerateToken(IdentityUser user);
    Task<RefreshTokenResponseDTO> VerifyToken(TokenRequestDTO tokenRequest);
    
}
