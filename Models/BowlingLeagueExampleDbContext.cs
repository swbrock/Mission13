using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public partial class BowlingLeagueExampleDbContext : DbContext 
    {
        public BowlingLeagueExampleDbContext()
        {

        }
        public BowlingLeagueExampleDbContext(DbContextOptions<BowlingLeagueExampleDbContext> options) : base (options)
        {

        }
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
