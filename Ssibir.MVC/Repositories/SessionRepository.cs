using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StolicaSibiri.DAL.Repositories.IRepositories;
using StolicaSibiri.DAL.Models;
using StolicaSibiri.DAL.Models.Context;

namespace StolicaSibiri.DAL.Repositories
{
	public class SessionRepository : BaseRepository<SessionEntity>, ISessionRepository
	{
		public SessionRepository(DbCatalog context): base(context)
		{
			this.context = context;
		}
		protected override System.Data.Entity.DbSet<SessionEntity> GetTable()
		{
			return context.Sessions;
		}
		public IList<SessionEntity> GetByUserId(Guid userId)
		{
			return GetTable().Where(s => s.UserId == userId & s.EndDate==null).ToList();
		}
	}
}
