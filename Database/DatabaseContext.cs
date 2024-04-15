using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WatchMNS.Models;

namespace WatchMNS.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Document> Document{ get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<DocumentType> DocumentType{ get; set; }
        public DbSet<LateMiss> LateMiss { get; set; }
        public DbSet<LateMissDoc> LateMissDoc { get; set; }
        public DbSet<LateMissStatus> LateMissStatus { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }
        public DbSet<ProfessionnalStatus> ProfessionnalStatus { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingType> TrainingType { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;Database=watcherdb;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
