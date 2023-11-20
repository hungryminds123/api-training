using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Interfaces;
using Core.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repositories.Interface;

namespace Core.Concrete;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    
    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public  async Task<AuthModel> ValidateUserAsync(
        string userName, 
        string password)
    {
        var userDetails =
            await _userRepository.Find(
                x => x.UserEmail.Equals(userName) &&
                     x.UserPassword.Equals(password));

        if (userDetails != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return new AuthModel()
            {
                AcessToken = GenerateSecurityToken(tokenHandler),
                UserId = userDetails.UserId,
                AccessTokenExpiryTime = System.DateTime.UtcNow.AddMinutes(30)
            };
        }
        return null;
    }
    
    
    
    private string GenerateSecurityToken(JwtSecurityTokenHandler tokenHandler)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("A63153-11C1-4919-9133-EFAF99A9B456"));

        var signingCredentials
            = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor
            = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = signingCredentials,
                Issuer = null,
                Audience = null,
                Subject = new ClaimsIdentity((GetClaims()))
            };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private IEnumerable<Claim> GetClaims()
    {
        IEnumerable<Claim> claims = new Claim[]
        {
            new Claim("UserName", "Test"),
            new Claim("IsAdmin", "True")
        };

        return claims;
    }
}