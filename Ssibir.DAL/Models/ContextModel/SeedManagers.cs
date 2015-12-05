using DevOne.Security.Cryptography.BCrypt;
using Ssibir.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Models.ContextModel
{
    public class SeedManagers
    {
        private readonly string salt = BCryptHelper.GenerateSalt();

        public IEnumerable<Manager> GetManagers() {

            return new List<Manager>
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
        }
    }
}
