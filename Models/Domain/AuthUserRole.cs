using System;
using System.Collections.Generic;

namespace LojistaPro.Models.Domain;

public partial class AuthUserRole
{
    public int Id { get; set; }

    public string? AuthUserId { get; set; }

    public string? RoleId { get; set; }

    public DateTime CriadoPor { get; set; }

    public DateTime CriadoEm { get; set; }
    public virtual AuthUser AuthUser { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}
