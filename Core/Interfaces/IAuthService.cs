using Core.ViewModels;

namespace Core.Interfaces;

public interface IAuthService
{
    Task<AuthModel> ValidateUserAsync(string userName, string password);
}