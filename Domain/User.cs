namespace Domain;

public class User : BaseEntity
{
    public int UserId { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string UserPassword { get; set; }
    
    public string UserEmail { get; set; }
}