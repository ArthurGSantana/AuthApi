using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi;

public class TokenJwtBuilder
{
    private SecurityKey? _securityKey = null;
    private string? _subject = null;
    private string? _issuer = null;
    private string? _audience = null;
    private int _expiresInMinutes = 5;
    private Dictionary<string, string> claims = new();

    public TokenJwtBuilder AddSecurityKey(SecurityKey securityKey)
    {
        _securityKey = securityKey;
        return this;
    }

    public TokenJwtBuilder AddSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    public TokenJwtBuilder AddIssuer(string issuer)
    {
        _issuer = issuer;
        return this;
    }

    public TokenJwtBuilder AddAudience(string audience)
    {
        _audience = audience;
        return this;
    }

    public TokenJwtBuilder AddExpiresInMinutes(int expiresInMinutes)
    {
        _expiresInMinutes = expiresInMinutes;
        return this;
    }

    public TokenJwtBuilder AddClaim(string type, string value)
    {
        claims.Add(type, value);
        return this;
    }

    private void EnsureArguments()
    {
        if (_securityKey == null)
        {
            throw new ArgumentNullException(nameof(_securityKey));
        }

        if (string.IsNullOrEmpty(_subject))
        {
            throw new ArgumentNullException(nameof(_subject));
        }

        if (string.IsNullOrEmpty(_issuer))
        {
            throw new ArgumentNullException(nameof(_issuer));
        }

        if (string.IsNullOrEmpty(_audience))
        {
            throw new ArgumentNullException(nameof(_audience));
        }
    }

    public TokenJwt Build()
    {
        EnsureArguments();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _subject!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(this.claims.Select(c => new Claim(c.Key, c.Value)));

        var token = new JwtSecurityToken(
            _issuer,
            _audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_expiresInMinutes),
            signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.Aes128CbcHmacSha256)
        );

        return new TokenJwt(token);
    }
}
