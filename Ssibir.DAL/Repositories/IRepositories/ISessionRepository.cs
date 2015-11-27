using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssibir.DAL.Models;

namespace Ssibir.DAL.Repositories.IRepositories
{
	public interface ISessionRepository :IBaseRepository<SessionEntity>
	{
		IList<SessionEntity> GetByUserId(Guid userId);
	}
}
