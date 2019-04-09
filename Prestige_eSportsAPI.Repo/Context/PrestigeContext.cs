using Microsoft.EntityFrameworkCore;
using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;

namespace Prestige_eSports.Repo.Context
{
    public class PrestigeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("myrealconnectionstring");
        }

        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
