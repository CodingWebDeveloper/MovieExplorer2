using MovieExplorer.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Data.Seeding
{
    public class GenreSeeder : ISeeder
    {
        private const string PATH = "../../Data/MovieExplorer.Data/JsonData";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            IEnumerable<Genre> genres = new List<Genre>()
            {
                new Genre
                {
                    Name = "Action",
                },
                new Genre
                {
                    Name = "Comedy",
                },
                new Genre
                {
                    Name = "Criminal",
                },
                new Genre
                {
                    Name = "Thriller",
                },
                new Genre
                {
                    Name = "Horror",
                },
                new Genre
                {
                    Name = "Science fiction",
                },
                new Genre
                {
                    Name = "Drama",
                },
                new Genre
                {
                    Name = "Romantic",
                },
                new Genre
                {
                    Name = "Adventure",
                },
                new Genre
                {
                    Name = "Mystery",
                },
                new Genre
                {
                    Name = "Fantasy",
                },
                new Genre
                {
                    Name = "Animation",
                },
            };

            await dbContext.Genres.AddRangeAsync(genres);

            await dbContext.SaveChangesAsync();
        }
    }
}
