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
	public class TourRepository : BaseRepository<Tour>, ITourRepository
	{
		public TourRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Tour> GetTable()
		{
			return context.Set<Tour>();
		}

		public override void Save(Tour entity)
		{

			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				GetTable().Add(entity);
			}
			else
			{
				Tour dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return;
				dbEntity.Title = entity.Title;
				dbEntity.Cost = entity.Cost;
				dbEntity.DirectionId = entity.DirectionId;
				dbEntity.HotelId = entity.HotelId;
				dbEntity.imageUrl = entity.imageUrl;
				dbEntity.isHot = entity.isHot;
				dbEntity.Nights = entity.Nights;
				dbEntity.StartDate = entity.StartDate;
				dbEntity.OperatorId = entity.OperatorId;
				dbEntity.Type = entity.Type;
				//dbEntity.Trips = entity.Trips;
			}
			context.SaveChanges();
		}
	}
}
