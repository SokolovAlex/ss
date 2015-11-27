using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Models;
using StolicaSibiri.DAL.Repositories.IRepositories;
using StolicaSibiri.DAL.Models.Context;

namespace StolicaSibiri.DAL.Repositories
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
