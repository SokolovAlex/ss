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
	public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
	{
		public OperatorRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Operator> GetTable()
		{
			return context.Operators;
		}

        public override Operator Save(Operator entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				Operator dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return null;
				dbEntity.Title = entity.Title;
				dbEntity.ImageUrl = entity.ImageUrl;
				//dbEntity.Tours = entity.Tours;
                return dbEntity;
			}
		}
	}
}