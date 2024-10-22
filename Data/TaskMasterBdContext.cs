using Microsoft.EntityFrameworkCore;
using Task = TaskMasterApi.Data.Models.Task;

namespace TaskMasterApi.Data;

public partial class TaskMasterBdContext : DbContext
{
    public TaskMasterBdContext()
    {
    }

    public TaskMasterBdContext(DbContextOptions<TaskMasterBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__Tasks__9FCAD1C581BEDFF2");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
