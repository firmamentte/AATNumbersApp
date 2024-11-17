using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AATNumbersApp.Data.Entities;

public partial class NumberDbContext : DbContext
{
    public NumberDbContext()
    {
    }

    public NumberDbContext(DbContextOptions<NumberDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Number> Numbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(StaticClass.DatabaseHelper.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Number>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
