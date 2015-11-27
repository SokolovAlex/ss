using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;
using Ssibir.DAL.Repositories.IRepositories;
using System.Data.Entity;
using Ssibir.DAL.Models.Context;

namespace Ssibir.DAL.Repositories
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
			return context.Directions;
		}
	}
}
