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

        }
    }
}
