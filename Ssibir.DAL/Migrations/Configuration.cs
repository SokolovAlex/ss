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
            //OnceSeed(context);
        }

        private void OnceSeed(Models.Context.DbCatalog context)
        {
            var toursData2 = new initDataTours2();
            var tours2 = toursData2.GetTours();
            tours2.ForEach(d => context.Tours.AddOrUpdate(d));

            var ms = new List<Manager>
                          {
                              new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="m",
                                     Job = JobGrid.Director,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Елена",
                                     Email = "s5sibir@yandex.ru",
                                     Phone = "89137040184",
                                     Skype = "sokolova.elena2",
                                     Description = "Генеральный Директор, специалист по круизам, специалист по США",
                                     key = "SokolovaElena"
                                },
                             new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="s",
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколов",
                                     FirstName ="Алексей",
                                     Job = JobGrid.MidManager,
                                     Email = "s77sibir@yandex.ru",
                                     Phone = "89139277868",
                                     Skype = "ierroglif",
                                     Vk = "http://vk.com/id701209",
                                     Description = "Специалист по Европе",
                                     key = "SokolovAlex"
                                },
                            new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="e",
                                     Job = JobGrid.commercialDirector,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколов",
                                     FirstName ="Евгений",
                                     Description = "Специалист по Азии",
                                     key = "SokolovEvgeniy"
                                },
                            new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="alina",
                                     Job = JobGrid.SeniorManager,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Алина",
                                     Description = "Специалист по авиаперелетам",
                                     key = "SokolovaAlina"
                                },
                            new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="i",
                                     Job = JobGrid.MidManager,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Ирина",
                                     Vk = "http://vk.com/naumenko",
                                     Description = "Специалист по США",
                                     key = "SokolovaIrina"
                                }
                          };
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
