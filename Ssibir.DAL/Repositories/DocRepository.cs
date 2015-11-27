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
	public class DocRepository : BaseRepository<Doc>, IDocRepository
	{
		public DocRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Doc> GetTable()
		{
			return context.Docs;
		}
	}
}
