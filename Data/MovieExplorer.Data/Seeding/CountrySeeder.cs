namespace MovieExplorer.Data.Seeding
{
    using MovieExplorer.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountrySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.Countries.Any())
            //{
            //    return;
            //}

            IEnumerable<Country> coutries = new List<Country>()
            {
                new Country
                {
                    Name = "USA",
                },
                new Country
                {
                    Name = "Canada",
                },
                new Country
                {
                    Name = "Japan",
                },
            };
        }
    }
}
