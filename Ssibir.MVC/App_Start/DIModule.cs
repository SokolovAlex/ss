using Ninject.Modules;
using Ssibir.DAL.Repositories;
using Ssibir.DAL.Repositories.IRepositories;
using Ssibir.web.Core.Providers;
using Ssibir.web.Core.Providers.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.App_Start
{
	public class DIModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IClientRepository>().To<ClientRepository>();
			Bind<ICommentRepository>().To<CommentRepository>();
			Bind<IDirectionRepository>().To<DirectionRepository>();
			Bind<IDocRepository>().To<DocRepository>();
			Bind<IHotelRepository>().To<HotelRepository>();
			Bind<ILocationRepository>().To<LocationRepository>();
			Bind<IManagerRepository>().To<ManagerRepository>();
			Bind<IOperatorRepository>().To<OperatorRepository>();
			Bind<IPageRepository>().To<PageRepository>();
			Bind<ISessionRepository>().To<SessionRepository>();
			Bind<ITourRepository>().To<TourRepository>();
			Bind<ITripRepository>().To<TripRepository>();
			Bind<IUserProvider>().To<UserProvider>();
			Bind<IUserRoleProvider>().To<UserRoleProvider>();
		}
	}
}