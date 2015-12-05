namespace Ssibir.DAL.Migrations
{
    using DevOne.Security.Cryptography.BCrypt;
    using Models;
    using Models.ContextModel;
    using Models.Enums;
    using Models.Enum;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.Context.DbCatalog>
    {
        private readonly string salt = BCryptHelper.GenerateSalt();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.Context.DbCatalog context)
        {
            OnceSeed(context);
        }

        private void OnceSeed(Models.Context.DbCatalog context)
        {
            var toursData2 = new initDataTours2();
            var tours2 = toursData2.GetTours();
            tours2.ForEach(d => context.Tours.AddOrUpdate(d));

            var ms = (new SeedManagers()).GetManagers().ToList();
            ms.ForEach(d => context.Managers.AddOrUpdate(d));

            var pages = toursData2.GetToursPages(ms.FirstOrDefault().Id);

            pages.ForEach(d => context.Pages.AddOrUpdate(d));

            var dirData = new initDataDirection();

            var dirs = dirData.GetDirectios();
            dirs.ForEach(d => context.Directions.AddOrUpdate(d));

            List<Page> dirPages = dirData.GetDirectionPages();
            dirPages.ForEach(d => context.Pages.AddOrUpdate(d));

            var toursData = new initDataTours();
            List<Tour> otherTours = toursData.GetTours();
            otherTours.ForEach(d => context.Tours.AddOrUpdate(d));
            List<Page> otherTourPages = toursData.GetTourPages();
            otherTourPages.ForEach(d => context.Pages.AddOrUpdate(d));

            var op = new List<Operator>
                          {
                              new Operator()
                                {
                                     Id = Guid.NewGuid(),
                                     Title = "TEZ"
                                }
                          };
            op.ForEach(d => context.Operators.AddOrUpdate(d));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw (ex);
            }

        }
    }
}
