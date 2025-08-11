using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LojistaPro.Models.Domain;

public partial class Role : IdentityRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int AuthUserRoleId { get; set; }

    public DateTime CriadoEm { get; set; }

    public DateTime CriadoPor { get; set; }

    public virtual ICollection<AuthUserRole> AuthUserRoles { get; set; } = new List<AuthUserRole>();
}
