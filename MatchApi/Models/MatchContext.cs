using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Models
{
    public class MatchContext : DbContext
    {
        //The constructor just calls the constructor in the DbContext class
        public MatchContext(DbContextOptions<MatchContext> options) : base(options) { }

        //We only have a single table with Matches which is represented by this DbSet
        public DbSet<Match> Matches { get; set; }
    }
}
