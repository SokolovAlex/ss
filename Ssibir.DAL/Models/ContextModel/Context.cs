using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ssibir.DAL.Models.Enums;

namespace Ssibir.DAL.Models.Context
{
	public class DbCatalog : DbContext
    {
        public DbCatalog()
            : base("ssdb")
        {
        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<Doc> Docs { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Operator> Operators { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }

		public DbSet<Page> Pages { get; set; }

		public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new TouristConfiguration());
            base.OnModelCreating(modelBuilder);

            // место для вызовов Entity Framework Fluent API
            modelBuilder.Entity<Client>()
                .HasOptional(a => a.Docs)
                .WithOptionalPrincipal(g => g.Client);

            //modelBuilder.Entity<Tour>()
            //    .HasOptional(a => a.Trip)
            //    .WithOptionalPrincipal(g => g.Tour);
        }
    }
}
