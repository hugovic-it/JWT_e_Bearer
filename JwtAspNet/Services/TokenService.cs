using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet.Services;
public class TokenService
{
    public string Create(){
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            algorithm:SecurityAlgorithms.HmacSha256 );
        
        var tokenDescriptor = new SecurityTokenDescriptor{
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        new Claim(type: ClaimTypes.Name, value:"");
        new Claim(type: ClaimTypes.Role, value:"");
        //new Claim(type: ClaimTypes.GivenName, value:""); //Nome Real do usuário
        //new Claim(type: ClaimTypes.Email, value:"");

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}