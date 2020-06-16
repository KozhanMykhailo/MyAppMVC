using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAppMVC.Models
{
	public class MatchesContext : DbContext
    {
        public MatchesContext() : base("ControlEntityF.Properties.Settings.MatchesConnectionString")
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<GemaPlayer> GemaPlayers { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
    
}