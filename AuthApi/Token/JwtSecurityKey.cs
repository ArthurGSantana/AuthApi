using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi;

public class JwtSecurityKey
{
    public static SymmetricSecurityKey Create(string secret) => new(Encoding.ASCII.GetBytes(secret));
}
