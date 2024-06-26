using JwtAspNet.Models;
using JwtAspNet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", (TokenService service) 
    => 
{   
    var user = new User (
        1,
        "Hugo Victor" , 
        "xyz@#gmail.com", 
        "https>//hugovictordev.com.br", 
        "XYXZ",
        new[]{ "student","premium"});
   return service.Create(user);  
});



app.Run();
    