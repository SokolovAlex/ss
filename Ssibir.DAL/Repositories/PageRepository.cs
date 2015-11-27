using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;
using Ssibir.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Repositories
{
	public class PageRepository : BaseIntRepository<Page>, IPageRepository
	{
		public PageRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Page> GetTable()
		{
			return context.Pages;
		}

        public override Page Save(Page entity)
		{
			if (entity.IsNew())
			{
				return GetTable().Add(entity);
			}
			else
			{
				Page dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return null;
				dbEntity.Comments = entity.Comments;
				dbEntity.key = entity.key;
				dbEntity.Html = entity.Html;
				dbEntity.Images = entity.Images;
				dbEntity.LocationId = entity.LocationId;
				dbEntity.OperatorId = entity.OperatorId;
				dbEntity.Title = entity.Title;
				dbEntity.TypeId = entity.TypeId;
                dbEntity.TourId = entity.TourId;
                return dbEntity;
			}
		}
	}
}
