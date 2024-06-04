using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAspNet.Services;
public class TokenService
{
    public string Create(){
        var handler = new JwtSecurityTokenHandler();

        var token = handler.CreateToken();
        return handler.WriteToken(token);
    }
}