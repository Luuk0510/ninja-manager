using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ninja_manager.Models;

public partial class NinjaContext : DbContext
{
    public NinjaContext()
    {
    }

    public NinjaContext(DbContextOptions<NinjaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Ninja> Ninjas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK_categorie_1");

            entity.ToTable("categorie");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Categorie>().HasData(
            new Categorie { Name = "Head" },
            new Categorie { Name = "Hands" },
            new Categorie { Name = "Feet" },
            new Categorie { Name = "Necklace" },
            new Categorie { Name = "Chest" },
            new Categorie { Name = "Ring" }
        );

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.ToTable("equipment");

            entity.HasIndex(e => e.CategoryName, "IX_equipment_category_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Agility).HasColumnName("agility");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("category_name");
            entity.Property(e => e.Gold).HasColumnName("gold");
            entity.Property(e => e.Intelligence).HasColumnName("intelligence");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Strength).HasColumnName("strength");

            entity.HasOne(d => d.CategoryNameNavigation).WithMany(p => p.Equipments)
                .HasForeignKey(d => d.CategoryName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_equipment_categorie");
        });

        modelBuilder.Entity<Equipment>().HasData(
            // Head Category
            new Equipment { Id = 1, Name = "Straw Hat", CategoryName = "Head", Strength = 5, Agility = 10, Intelligence = 2, Gold = 2 },
            new Equipment { Id = 2, Name = "Iron Helmet", CategoryName = "Head", Strength = 27, Agility = -5, Intelligence = 10, Gold = 50 },
            new Equipment { Id = 3, Name = "Samurai Helmet", CategoryName = "Head", Strength = 75, Agility = -20, Intelligence = 12, Gold = 140 },

            // Hands Category
            new Equipment { Id = 4, Name = "Wooden Sword", CategoryName = "Hands", Strength = 10, Agility = 10, Intelligence = 1, Gold = 10 },
            new Equipment { Id = 5, Name = "Steel Dagger", CategoryName = "Hands", Strength = 53, Agility = 45, Intelligence = 3, Gold = 55 },
            new Equipment { Id = 6, Name = "Ninja Katana", CategoryName = "Hands", Strength = 200, Agility = 50, Intelligence = 2, Gold = 200 },

            // Feet Category
            new Equipment { Id = 7, Name = "Sandals", CategoryName = "Feet", Strength = -4, Agility = 19, Intelligence = 1, Gold = 5 },
            new Equipment { Id = 8, Name = "Leather Boots", CategoryName = "Feet", Strength = 12, Agility = 43, Intelligence = 11, Gold = 50 },
            new Equipment { Id = 9, Name = "Ninja Boots", CategoryName = "Feet", Strength = 32, Agility = 140, Intelligence = 20, Gold = 100 },

            // Necklace Category
            new Equipment { Id = 10, Name = "Bead Necklace", CategoryName = "Necklace", Strength = -5, Agility = 1, Intelligence = 13, Gold = 2 },
            new Equipment { Id = 11, Name = "Amulet of Health", CategoryName = "Necklace", Strength = 0, Agility = 10, Intelligence = 26, Gold = 50 },
            new Equipment { Id = 12, Name = "Wisdom Amulet", CategoryName = "Necklace", Strength = 2, Agility = 20, Intelligence = 52, Gold = 100 },

            // Chest Category
            new Equipment { Id = 13, Name = "Cloth Robe", CategoryName = "Chest", Strength = 4, Agility = 0, Intelligence = 2, Gold = 10 },
            new Equipment { Id = 14, Name = "Chainmail Armor", CategoryName = "Chest", Strength = 40, Agility = -8, Intelligence = 3, Gold = 50 },
            new Equipment { Id = 15, Name = "Dragon Scale Armor", CategoryName = "Chest", Strength = 100, Agility = -15, Intelligence = 7, Gold = 182 },

            // Ring Category
            new Equipment { Id = 16, Name = "Wooden Ring", CategoryName = "Ring", Strength = 1, Agility = 10, Intelligence = 1, Gold = 10 },
            new Equipment { Id = 17, Name = "Silver Ring", CategoryName = "Ring", Strength = 52, Agility = 40, Intelligence = 31, Gold = 80 },
            new Equipment { Id = 18, Name = "Ring of Power", CategoryName = "Ring", Strength = 999, Agility = 999, Intelligence = 999, Gold = 631 }
        );

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => new { e.NinjaId, e.EquipmentId });

            entity.ToTable("inventory");

            entity.HasIndex(e => e.EquipmentId, "IX_inventory_equipment_id");

            entity.Property(e => e.NinjaId).HasColumnName("ninja_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Gold).HasColumnName("gold");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_inventory_equipment");

            entity.HasOne(d => d.Ninja).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.NinjaId)
                .HasConstraintName("FK_inventory_ninja");
        });

        modelBuilder.Entity<Ninja>(entity =>
        {
            entity.ToTable("ninja");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gold).HasColumnName("gold");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
