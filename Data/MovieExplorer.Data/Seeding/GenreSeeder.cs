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
                await this.SendToJson(dbContext);
                using (StreamReader reader = new StreamReader(PATH + "/genre.json"))
                {
                    string inputJson = reader.ReadToEnd().Trim();
                    IEnumerable<Genre> genresFromJson = JsonConvert.DeserializeObject<IEnumerable<Genre>>(inputJson);
                    foreach (var genre in genresFromJson)
                    {
                        if (!dbContext.Genres.Any(x => x.Name == genre.Name))
                        {
                            await dbContext.AddAsync(genre);
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task SendToJson(ApplicationDbContext dbContext)
        {
            var genres = dbContext.Genres.Select(x => new
            {
                Name = x.Name,
            }).ToArray();

            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            using FileStream file = new FileStream(PATH + "/genre.json", FileMode.OpenOrCreate);
            file.Close();

            string inputJson = string.Empty;
            string json = string.Empty;

            using StreamReader reader = new StreamReader(file.Name);
            inputJson = reader.ReadToEnd().Trim();

            if (string.IsNullOrEmpty(inputJson))
            {
                json = JsonConvert.SerializeObject(genres.Select(x => new { Name = x.Name }), Formatting.Indented);
                reader.Close();
                await File.WriteAllTextAsync(file.Name, json);
                return;
            }

            List<Genre> genresFromJson = JsonConvert.DeserializeObject<IEnumerable<Genre>>(inputJson).ToList();

            foreach (var genre in genres)
            {
                if (!genresFromJson.Any(x => x.Name == genre.Name))
                {
                    genresFromJson.Add(new Genre { Name = genre.Name });
                }
            }

            reader.Close();
            json = JsonConvert.SerializeObject(genresFromJson.Select(x => new { Name = x.Name }), Formatting.Indented);
            await File.WriteAllTextAsync(file.Name, json);
        }
    }
}
