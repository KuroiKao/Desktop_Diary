using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Desktop_Diary.BaseContext;

public partial class DiaryBaseContext : DbContext
{
    public DiaryBaseContext()
    {
    }

    public DiaryBaseContext(DbContextOptions<DiaryBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DiaryBase;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.DateCompletion).HasColumnType("date");
            entity.Property(e => e.DateCreation).HasColumnType("date");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Header).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsCompleted).HasColumnType("0");
            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Users2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Login).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
