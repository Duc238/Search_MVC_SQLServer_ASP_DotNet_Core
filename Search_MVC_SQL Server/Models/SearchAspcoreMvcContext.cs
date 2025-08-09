using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Search_MVC_SQL_Server.Models;

public partial class SearchAspcoreMvcContext : DbContext
{
    public SearchAspcoreMvcContext()
    {
    }

    public SearchAspcoreMvcContext(DbContextOptions<SearchAspcoreMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0768646C7F");

            entity.Property(e => e.CategoryName).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07CCFA33A8");

            entity.Property(e => e.ProductName).HasMaxLength(200);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__IdCate__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
