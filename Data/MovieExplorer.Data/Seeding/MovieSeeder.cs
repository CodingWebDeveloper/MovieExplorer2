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
    public class MovieSeeder : ISeeder
    {
        private const string PATH = "../../Data/MovieExplorer.Data/JsonData";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //await this.SendToJosn(dbContext);
            //using StreamReader reader = new StreamReader(PATH + "/movie.json");
            //string inputJson = reader.ReadToEnd().Trim();
            //var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(inputJson).ToList();
            //foreach (var movie in movies)
            //{
            //        foreach (var actor in movie.MovieActors)
            //        {
            //            if (!dbContext.Actors.Any(a => $"{a.FirstName} {a.MiddleName} {a.LastName}" 
            //                == $"{actor.Actor.FirstName} {actor.Actor.MiddleName} {actor.Actor.LastName}"))
            //            {
            //                await dbContext.Actors.AddAsync(actor.Actor);
            //            }
            //        }



            //        var servise=serviceProvider.GetService(DirectorService)

            //        if (director == null)
            //        {
            //            await dbContext.AddAsync(movie.Director);
            //        }

            //        Country country = dbContext.Countries.FirstOrDefault(c => c.Name == movie.Country.Name);

            //        if (country == null)
            //        {
            //            await dbContext.AddAsync(movie.Country);
            //        }
            //}

            //await dbContext.SaveChangesAsync();
            //foreach (var movie in movies)
            //{
            //    if (!dbContext.Movies.Any(m => m.Title == movie.Title))
            //    {
            //       await dbContext.Movies.AddAsync(movie);
            //    }
            //}

            Movie movie = new Movie
            {
                Title = "Bad Boys for Life",
                ReleaseDate = DateTime.Parse("2020/01/17"),
                Rate = 7.2,
                Minutes = 124,
                ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
                Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
                Country = new Country { Name = "USA" },
                Director = new Director {FirstName="Edi ", LastName = "El Abri" },
                MovieActors = new List<MovieActor>()
                {
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Will",
                            LastName = "Smith",
                        },
                    },
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Martin",
                            LastName = "Loruns",
                        },
                    },
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Vnessa",
                            LastName = "Hudgens",
                        },


                    },
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Alexander",
                            LastName = "Ludwig",
                        },
                    },
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Paola",
                            LastName = "Nunez",
                        },
                    },
                    new MovieActor
                    {
                        Actor = new Actor
                        {
                            FirstName = "Charles",
                            LastName = "Melton",
                        },
                    },
                },

                Genres = new List<MovieGenre>()
                {
                    new MovieGenre
                    {
                        Genre = new Genre
                        {
                            Name = "Action",
                        },
                    },

                    new MovieGenre
                    {
                        Genre = new Genre
                        {
                            Name = "Criminal",
                        },
                    },
                },
            };
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();
            //await dbContext.Movies.AddAsync(new Movie
            //{
            //    Title = "The crying woman",
            //    ReleaseDate = DateTime.Parse("2003/12/3"),
            //    Rate = 5.20,
            //    Minutes = 130,
            //    Director = new Director { FirstName = "Steven", LastName = "Hocking" },
            //    ImageUrl = "https://th.bing.com/th/id/OIP.Wv4K6rxOMC8ezdydyoTXPQHaEH?pid=ImgDet&rs=1",
            //    Trailer = "https://www.youtube.com/embed/FEFTEyFUSzM",
            //    Country = new Country { Name = "New Guinea" },
            //});

            //await dbContext.SaveChangesAsync();
        }

        private async Task SendToJosn(ApplicationDbContext dbContext)
        {
            var movies = dbContext.Movies.Select(m => new
            {
                m.Title,
                m.ReleaseDate,
                m.Rate,
                m.Minutes,
                m.ImageUrl,
                m.Trailer,
                Actors = m.MovieActors,
                Director =m.Director,
                Country = m.Country,
                Genres = m.Genres,
            });

            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            using FileStream file = new FileStream(PATH + "/movie.json", FileMode.OpenOrCreate);
            file.Close();

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            await File.WriteAllTextAsync(PATH + "/movie.json", json);
        }
    }
}