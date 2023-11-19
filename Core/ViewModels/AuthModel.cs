namespace Core.ViewModels;

public class AuthModel
{
    public string? UserEmailId { get; set; }
    
    public int UserId { get; set; }
    
    public string? AcessToken { get; set; }
    
    public string? RefreshToken { get; set; }  // include this functionality later
    
    public DateTime? AccessTokenExpiryTime { get; set; }
    
    
}