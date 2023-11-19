using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TrainingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController :  ControllerBase
{
    public AuthenticationController()
    {
            
    }
    
    [HttpGet]
    public async Task<AuthModel> ValidateUser(string userName,string password)
    {
        AuthModel model = new AuthModel();
        
        if (userName == "Test" && password == "Password")
        {
            model.AcessToken = GenerateSecurityToken(new JwtSecurityTokenHandler());
        }
        
        return await Task.FromResult(model);
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