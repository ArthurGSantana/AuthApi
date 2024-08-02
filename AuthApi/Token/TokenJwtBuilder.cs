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
}
