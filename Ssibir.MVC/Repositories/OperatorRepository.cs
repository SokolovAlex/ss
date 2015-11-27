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
	public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
	{
		public OperatorRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Operator> GetTable()
		{
			return context.Set<Operator>();
		}

		public override void Save(Operator entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				GetTable().Add(entity);
			}
			else
			{
				Operator dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return;
				dbEntity.Title = entity.Title;
				dbEntity.ImageUrl = entity.ImageUrl;
				//dbEntity.Tours = entity.Tours;
			}
			context.SaveChanges();
		}
	}
}