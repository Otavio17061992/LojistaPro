using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LojistaPro.Models.Domain;

public partial class AuthUser : IdentityUser
{
    // public int UserId { get; set; }

    public new string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public int Ativo { get; set; }

    public string CriadoEm { get; set; } = null!;

    public string CriadoPor { get; set; } = null!;

    public string UserHashPassWord { get; set; } = null!;

    public virtual ICollection<AuthUserRole> AuthUserRoles { get; set; } = new List<AuthUserRole>();
}
