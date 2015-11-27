using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.DAL.Models.Context;

namespace Ssibir.DAL.Repositories
{
	public class CommentRepository: BaseRepository<Comment>, ICommentRepository
	{
		public CommentRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override System.Data.Entity.DbSet<Comment> GetTable()
		{
			return context.Comments;
		}
	}
}
