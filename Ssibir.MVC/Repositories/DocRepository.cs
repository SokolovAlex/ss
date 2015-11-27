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
	public class DocRepository : BaseRepository<Doc>, IDocRepository
	{
		public DocRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Doc> GetTable()
		{
			return context.Set<Doc>();
		}
	}
}
