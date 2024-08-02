using System.IdentityModel.Tokens.Jwt;

namespace AuthApi;

public class TokenJwt
{
    private JwtSecurityToken _token;

    internal TokenJwt(JwtSecurityToken token)
    {
        _token = token;
    }

    public string? Value => new JwtSecurityTokenHandler().WriteToken(_token);
}
