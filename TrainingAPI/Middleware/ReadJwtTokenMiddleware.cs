
namespace TrainingAPI.Middleware;

public class ReadJwtTokenMiddleware
{

    private readonly RequestDelegate _next;
    
    public ReadJwtTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        
        /*
           Main Logic section 
            
         */   
        
        await _next(context);
    }
    
    
}