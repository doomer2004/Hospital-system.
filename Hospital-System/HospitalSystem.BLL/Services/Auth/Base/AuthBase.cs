using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FluentValidation;
using HospitalSystem.BLL.Extensions;
using HospitalSystem.Common.Models.Configs;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace HospitalSystem.BLL.Services.Auth.Base;

public class AuthBase<T> where T : class
{
    private readonly JwtConfig _jwtConfig;
    protected readonly UserManager<User> _userManager;

    protected AuthBase(JwtConfig jwtConfig, UserManager<User> userManager)
    {
        _jwtConfig = jwtConfig;
        _userManager = userManager;
    }
    
    protected async Task<AuthSuccessDTO> GenerateAuthSuccessDTO(User user)
    {
        try
        {
            var res = await GenerateRefreshTokenAsync(user);
            return new AuthSuccessDTO
            {
                AccessToken = await GenerateToken(user),
                RefreshToken = res
            };
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    private async Task<string> GenerateToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, await _userManager.GetRoleAsync(user)),
            }),
            Expires = DateTime.UtcNow.Add(_jwtConfig.RefreshTokenLifetime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience
        };
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return await Task.FromResult(jwtToken);
    }

    private string GenerateRefreshToken(User user)
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<string> GenerateRefreshTokenAsync(User user)
    {
        user.RefreshToken = GenerateRefreshToken(user);
        user.RefreshTokenExpiresAt = DateTimeOffset.UtcNow.Add(_jwtConfig.RefreshTokenLifetime);
        var userUpdated = await _userManager.UpdateAsync(user);
        if (!userUpdated.Succeeded)
        {
            throw new Exception("Unable to refresh token");
        }
        
        return user.RefreshToken;
    }
}