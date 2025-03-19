using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PR17;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Student; User=исп-34; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChivetVobchaga).HasColumnName("ChivetVObchaga");
            entity.Property(e => e.Familia)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdZachetnoKinigi).HasColumnName("idZachetnoKinigi");
            entity.Property(e => e.Ima)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
