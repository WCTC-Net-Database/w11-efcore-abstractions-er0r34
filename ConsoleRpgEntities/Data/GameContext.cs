using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; } // New DbSet
        public virtual DbSet<Weapon> Weapons { get; set; } // New DbSet
        public virtual DbSet<Armor> Armors { get; set; } // New DbSet

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH for Character hierarchy
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m => m.MonsterType)
                .HasValue<Goblin>("Goblin");

            // Configure TPH for Ability hierarchy
            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>(pa => pa.AbilityType)
                .HasValue<ShoveAbility>("ShoveAbility");

            // Configure many-to-many relationship
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithMany(a => a.Players)
                .UsingEntity(j => j.ToTable("PlayerAbilities"));

            // Configure one-to-one relationship between Player and Equipment
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Equipment)
                .WithOne()
                .HasForeignKey<Player>(p => p.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-one relationship between Equipment and Weapon
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Weapon)
                .WithOne()
                .HasForeignKey<Equipment>(e => e.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-one relationship between Equipment and Armor
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Armor)
                .WithOne()
                .HasForeignKey<Equipment>(e => e.ArmorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
