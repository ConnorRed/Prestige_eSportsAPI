using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;

namespace Prestige_eSports.Repo.Context
{
    public class PrestigeContext : DbContext
    {
        public PrestigeContext(DbContextOptions<PrestigeContext> options)
            : base(options)
        { }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
