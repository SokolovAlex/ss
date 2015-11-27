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
	public class ClientRepository : BaseRepository<Client>, IClientRepository
	{
		public ClientRepository()
		{
			context = new DbCatalog();
		}

		public ClientRepository(DbCatalog dataSource)
			: base(dataSource)
		{
			context = dataSource;
		}

		protected override DbSet<Client> GetTable()
		{
			return context.Clients;
		}

		public Client GetIdByNameAndPassword(string login, string password)
		{
			var man = GetTable().FirstOrDefault(x => x.Login == login && x.Password == password);
			return man;
		}

        public override Client Save(Client entity)
		{
			if (entity.IsNew())
			{
				entity.Id = Guid.NewGuid();
				return GetTable().Add(entity);
			}
			else
			{
				Client dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
				if (dbEntity == null) return null;
				dbEntity.Birth = entity.Birth;
				dbEntity.DocId = entity.DocId;
				dbEntity.FirstName = entity.FirstName;
				dbEntity.LastName = entity.LastName;
				dbEntity.MiddleName = entity.MiddleName;
				dbEntity.mobile = entity.mobile;
                return dbEntity;
			}
		}

		public Guid AddWithDocument(Client client)
		{
			return Guid.NewGuid();
		}

		public Client GetByName(string login)
		{
			var client = GetTable().FirstOrDefault(x => x.Login == login);
			return client;
		}
	}
}