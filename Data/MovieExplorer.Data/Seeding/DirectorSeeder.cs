using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Data.Seeding
{
    public class DirectorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Directors.Any())
            {
                return;
            }

            IEnumerable<Director> directors = new List<Director>()
            {
                new Director
                {
                    FirstName = "Edi",
                    LastName = "El Abri",
                },
                new Director
                {
                    FirstName = "Russo",
                    LastName = "Brothers",
                },
                new Director
                {
                    FirstName = "Jordan",
                    LastName = "Vogt-Roberts",
                },
                new Director
                {
                    FirstName = "Michael",
                    LastName = "Dougherty",
                },
                new Director
                {
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                },
                new Director
                {
                    FirstName = "James",
                    LastName = "Cameron",
                },
                new Director
                {
                    FirstName = "Haruo",
                    LastName = "Sotozaki",
                },
                new Director
                {
                    FirstName = "Christopher",
                    LastName = "Nolan",
                },
                new Director
                {
                    FirstName = "Oliver",
                    LastName = "Hirschbiegel",
                },
            };

            await dbContext.Directors.AddRangeAsync(directors);
            await dbContext.SaveChangesAsync();
        }
    }
}
