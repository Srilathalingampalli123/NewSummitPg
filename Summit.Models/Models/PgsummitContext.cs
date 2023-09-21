using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Summit.Models.Models;

public partial class PgsummitContext : DbContext
{
    public PgsummitContext()
    {
    }

    public PgsummitContext(DbContextOptions<PgsummitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerFna> CustomerFnas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=pgsummit;Username=postgres;Password=1230");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerFna>(entity =>
        {
            entity.HasKey(e => e.CustFnaId).HasName("customer_fna_pkey");

            entity.ToTable("customer_fna", "dbo");

            entity.Property(e => e.CustFnaId).HasColumnName("cust_fna_id");
            entity.Property(e => e.Addedby).HasColumnName("addedby");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DateAdded).HasColumnName("date_added");
            entity.Property(e => e.FnaId).HasColumnName("fna_id");
            entity.Property(e => e.Input)
                .HasColumnType("jsonb")
                .HasColumnName("input");
            entity.Property(e => e.LastUpdated).HasColumnName("last_updated");
            entity.Property(e => e.Output)
                .HasColumnType("jsonb")
                .HasColumnName("output");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
