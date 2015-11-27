using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Models;
using StolicaSibiri.DAL.Repositories.IRepositories;
using StolicaSibiri.DAL.Models.Context;
using System.Data.Entity;

namespace StolicaSibiri.DAL.Repositories
{
	public class TripRepository : BaseRepository<Trip>, ITripRepository
	{
		public TripRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Trip> GetTable()
		{
			return context.Set<Trip>();
		}
	}
}