using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }

        public DbSet<MatchModel> MatchModel { get; set; }
        public DbSet<PractiseModel> PractiseModel { get; set; }
        public DbSet<ShotModel> ShotModel { get; set; }


    }
}
