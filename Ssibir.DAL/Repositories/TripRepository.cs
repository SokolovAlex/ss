using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.DAL.Models.Context;
using System.Data.Entity;

namespace Ssibir.DAL.Repositories
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
			return context.Trips;
		}
	}
}