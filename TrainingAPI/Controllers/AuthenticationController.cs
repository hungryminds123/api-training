using Core.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TrainingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController :  ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet]
    public async Task<AuthModel> ValidateUser(string userName,string password)
    {
        var response = await _authService.ValidateUserAsync(userName, password);
        return await Task.FromResult(response);
    }
}