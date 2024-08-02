using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AuthApi;

public class ApplicationUser : IdentityUser
{
    [Column("USR_RG")]
    public string? RG { get; set; }
}
