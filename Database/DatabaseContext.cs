using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WatchMNS.Models;

namespace WatchMNS.Database
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<Client> ClientTable { get; set; }
        public DbSet<Document> DocumentTable { get; set; }
        public DbSet<DocumentStatus> DocumentStatusTable { get; set; }
        public DbSet<DocumentType> DocumentTypeTable { get; set; }
        public DbSet<LateMiss> LateMisseTable { get; set; }
        public DbSet<LateMissDoc> LateMissDocTable { get; set; }
        public DbSet<LateMissStatus> LateMissStatusTable { get; set; }
        public DbSet<Notification> NotificationTable { get; set; }
        public DbSet<NotificationType> NotificationTypeTable { get; set; }
        public DbSet<ProfessionnalStatus> ProfessionnalStatusTable { get; set; }
        public DbSet<Role> RoleTable { get; set; }
        public DbSet<Training> TrainingTable { get; set; }
        public DbSet<TrainingType> TrainingTypeTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;Database=watcherdb;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
