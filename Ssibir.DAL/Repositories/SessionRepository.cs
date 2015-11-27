using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;

namespace Ssibir.DAL.Repositories
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
        public SessionEntity Save(SessionEntity session)
        {
            if (session.IsNew())
            {
                session.Id = Guid.NewGuid();
                return GetTable().Add(session);
            }
            else
            {
                SessionEntity dbEntity = GetTable().SingleOrDefault(x => x.Id == session.Id);
                if (dbEntity == null) return null;
                dbEntity.Name = session.Name;
                dbEntity.Login = session.Login;
                dbEntity.RoleId = session.RoleId;
                dbEntity.StartDate = session.StartDate;
                return dbEntity;
            }
        }
	}
}
