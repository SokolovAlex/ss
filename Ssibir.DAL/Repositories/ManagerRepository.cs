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
	public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
	{
		public ManagerRepository()
			: base()
		{
		}

		public ManagerRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Manager> GetTable()
		{
			return context.Managers;
		}

		public Manager GetByNameAndPassword(string login, string password)
		{
			var man = GetTable().FirstOrDefault(x => x.Login == login && x.Password == password);
			return man;
		}

        public override Manager Save(Manager entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				Manager dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return null;
				dbEntity.Birth = entity.Birth;
				dbEntity.FirstName = entity.FirstName;
				dbEntity.LastName = entity.LastName;
				dbEntity.MiddleName = entity.MiddleName;
				dbEntity.key = entity.key;
				dbEntity.Skype = entity.Skype;
				dbEntity.JobId = entity.JobId;
				dbEntity.Phone = entity.Phone;
				dbEntity.Email = entity.Email;
				dbEntity.Vk = entity.Vk;
                return dbEntity;
			}
		}


		public Manager GetByName(string login)
		{
			var man = GetTable().FirstOrDefault(x => x.Login == login);
			return man;
		}
	}
}