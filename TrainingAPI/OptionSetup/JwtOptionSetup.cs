using Core.Models;
using Microsoft.Extensions.Options;

namespace TrainingAPI.OptionSetup;

public class JwtOptionSetup : IConfigureOptions<JwtModel>
{
    private readonly IConfiguration _configuration;

    public JwtOptionSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtModel options)
    {
        _configuration.GetSection("JsonWebTokenKeys").Bind(options);
    }
    
}