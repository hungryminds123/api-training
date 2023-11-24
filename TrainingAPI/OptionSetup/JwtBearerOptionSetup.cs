using Core.Models;
using TrainingAPI.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrainingAPI.OptionSetup;

public class JwtBearerOptionSetup : IConfigureNamedOptions<JwtBearerOptions>
{

    private readonly JwtModel _jwtOptions;
    
    public JwtBearerOptionSetup(
        IOptions<JwtModel> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public void Configure(
        string name, 
        JwtBearerOptions options)
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = _jwtOptions.GetTokenValidationParameters();
    }
    

    public void Configure(JwtBearerOptions options)
    {
        Configure(Options.DefaultName,options);
    }
}