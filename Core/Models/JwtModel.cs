namespace Core.Models;

public class JwtModel
{
    public bool ValidateIssuerSigningKey { get; set; }
    
    public string? IssuerSigningKey { get; set; }
    
    public bool ValidateIssuer { get; set; }
    
    public bool ValidateAudience { get; set; }
    
    public bool ValidateLifeTime { get; set; }
    
    public bool RequireExpirationTime { get; set; }
    
    
    
    
    
    
    
}