using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAPSolidaridadeAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<UserModality> UserModalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo podem ser adicionadas aqui

            // Exemplo de configuração para a classe User
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            // Configurações adicionais para outras classes de modelo podem ser adicionadas apropriadamente

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModality>()
           .HasKey(um => new { um.UserId, um.ModalityId });

            modelBuilder.Entity<UserModality>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserModalities)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserModality>()
                .HasOne(um => um.Modality)
                .WithMany(m => m.UserModalities)
                .HasForeignKey(um => um.ModalityId);

        }
    }
}
