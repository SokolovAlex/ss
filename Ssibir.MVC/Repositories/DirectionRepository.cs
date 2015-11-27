using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Models;
using StolicaSibiri.DAL.Repositories.IRepositories;
using System.Data.Entity;
using StolicaSibiri.DAL.Models.Context;

namespace StolicaSibiri.DAL.Repositories
{
	public class DirectionRepository: BaseRepository<Direction>, IDirectionRepository
	{
		public DirectionRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Direction> GetTable()
		{
			return context.Set<Direction>();
		}
	}
}
