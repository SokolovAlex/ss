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
	public class ClientRepository : BaseRepository<Client>, IClientRepository
	{
		public ClientRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Client> GetTable()
		{
			return context.Clients;
		}

		public Guid GetIdByNameAndPassword(string login, string password)
		{
			var man = GetTable().FirstOrDefault(x => x.Login == login && x.Password == password);
			if (man == null) return Guid.Empty;			
			return man.Id;
		}

		public override void Save(Client entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				GetTable().Add(entity);
			}
			else
			{
				Client dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return;
				dbEntity.Birth = entity.Birth;
				dbEntity.DocId = entity.DocId;
				dbEntity.FirstName = entity.FirstName;
				dbEntity.LastName = entity.LastName;
				dbEntity.MiddleName = entity.MiddleName;
				dbEntity.mobile = entity.mobile;
			}
			context.SaveChanges();
		}

		public Guid AddWithDocument(Client client)
		{
			return Guid.NewGuid();
		}
	}
}