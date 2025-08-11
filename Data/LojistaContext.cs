using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojistaPro.Data;

public partial class LojistaContext : DbContext
{
    public LojistaContext(DbContextOptions<LojistaContext> options)
        : base(options)
    {
    }

    // irei definir as entidades aqui
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

