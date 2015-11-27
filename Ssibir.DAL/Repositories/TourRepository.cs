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
	public class TourRepository : BaseRepository<Tour>, ITourRepository
	{
		public TourRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Tour> GetTable()
		{
			return context.Tours;
		}

        public override Tour Save(Tour entity)
		{

			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				Tour dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return null;
				dbEntity.Title = entity.Title;
				dbEntity.Cost = entity.Cost;
				dbEntity.DirectionId = entity.DirectionId;
				dbEntity.HotelId = entity.HotelId;
				dbEntity.isHot = entity.isHot;
				dbEntity.Nights = entity.Nights;
				dbEntity.StartDate = entity.StartDate;
				dbEntity.OperatorId = entity.OperatorId;
				dbEntity.Type = entity.Type;
				//dbEntity.Trips = entity.Trips;
                return dbEntity;
			}
		}
	}
}
