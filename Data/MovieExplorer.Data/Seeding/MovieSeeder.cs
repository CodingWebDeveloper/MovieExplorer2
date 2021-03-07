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
            if (dbContext.Movies.Any())
            {
                return;
            }

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
        }
    }
}