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
	public class LocationRepository: BaseRepository<Location>, ILocationRepository
	{
		public LocationRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Location> GetTable()
		{
			return context.Locations;
		}

        public override Location Save(Location entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				Location dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
                if (dbEntity == null) return null;
				dbEntity.Address = entity.Address;
				dbEntity.DirectionId = entity.DirectionId;
				dbEntity.GoogleMapLink = entity.GoogleMapLink;
				dbEntity.Hotels = entity.Hotels;
				dbEntity.Name = entity.Name;
                return dbEntity;
			}
			context.SaveChanges();
		}
	}
}
