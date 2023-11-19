using System.Text;
using Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace TrainingAPI.Extensions;

public static class JwtBearerOptionsSetupExtensions
{
    public static TokenValidationParameters GetTokenValidationParameters(
        this JwtModel _jwtModelOptions)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = _jwtModelOptions.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtModelOptions.IssuerSigningKey)),
            ValidateIssuer = _jwtModelOptions.ValidateIssuer,
            ValidateAudience = _jwtModelOptions.ValidateAudience,
            RequireExpirationTime = _jwtModelOptions.RequireExpirationTime,
            ValidateLifetime = _jwtModelOptions.ValidateLifeTime
        };
    }
    
    
}