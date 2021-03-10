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

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            //if (dbContext.Movies.Any())
            //{
            //    return;
            //}

            IEnumerable<Movie> movies = new List<Movie>()
            {
               // new Movie
               //{
               // Title = "Bloodshot",
               // ReleaseDate = DateTime.Parse("2020/03/13"),
               // Rate = 5.7,
               // Minutes = 109,
               // ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585130363/thumbs/themoviedb-1585130363-poster.jpg",
               // Trailer = "https://www.youtube.com/embed/vOUVVDWdXbo",
               // Country = dbContext.Countries.FirstOrDefault(x => x.Name == "USA"),
               // Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
               // MovieActors = new List<MovieActor>()
               // {
            //        new MovieActor
            //        {
            //             Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Sam" && x.LastName == "Heughan"),
            //        },
            //        new MovieActor
            //        {
            //           Actor= new Actor
            //            {
            //                FirstName = "Vin",
            //                LastName = "Diesel",
            //            },
            //        },
            //        new MovieActor
            //        {
            //             Actor = new Actor
            //             {
            //                FirstName = "Eiza",
            //                LastName = "Gonzalez",
            //             },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                 FirstName ="Toby",
            //                 LastName= "Kebbell",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Talulah",
            //                LastName = "Riley",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName ="Lamorne",
            //                LastName= "Morris",
            //            },
            //        },
            //    },
            //    Genres = new List<MovieGenre>()
            //    {
            //        new MovieGenre
            //        {
            //            Genre = new Genre
            //            {
            //                Name ="Action",
            //            },
            //        },
            //        new MovieGenre
            //        {
            //            Genre = new Genre
            //            {
            //                Name = "Science Fiction",
            //            },
            //        },
            //        new MovieGenre
            //        {
            //            Genre = new Genre
            //            {
            //                Name = "Drama",
            //            },
            //        },
            //    },
            //},

                new Movie
            {
                Title = "Avengers: Infinity War",
                ReleaseDate = DateTime.Parse("2018/04/27"),
                Rate = 9.0,
                Minutes = 149,
                ImageUrl = "https://filmisub.com/uploads/posts/zamunda/535884/thumbs/535884-poster.jpg",
                Trailer = "https://www.youtube.com/embed/6ZfuNTqbHE8",
                Country = dbContext.Countries.FirstOrDefault(x => x.Name == "USA"),
                Director = new Director { FirstName = "Russon ", LastName = "Brothers" },
                MovieActors = new List<MovieActor>()
                {
                    new MovieActor
                    {
                        Actor =dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Robert" && x.LastName == "Jr" ),
                    },
                    new MovieActor
                    {
                        Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Chris" && x.LastName == "Hemsworth"),
                    },
                    new MovieActor
                    {
                        Actor =dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Mark"),
                    },
                    new MovieActor
                    {
                       Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Chris" && x.LastName=="Evans"),
                    },
                    new MovieActor
                    {
                        Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Josh" && x.LastName == "Brolin"),
                    },
                    new MovieActor
                    {
                       Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Benedict" && x.LastName=="Cumberbatch"),
                    },
                },
                Genres = new List<MovieGenre>()
                    {
                        new MovieGenre
                        {
                            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                        },

                        new MovieGenre
                        {
                           Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Adventure"),
                        },
                        new MovieGenre
                        {
                            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Fantasy"),
                        },
                },
            },


            //new Movie
            //    {
            //        Title = "Bad Boys for Life",
            //        ReleaseDate = DateTime.Parse("2020/01/17"),
            //        Rate = 7.2,
            //        Minutes = 124,
            //        ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
            //        Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
            //        Country = new Country { Name = "USA" },
            //        Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
            //        MovieActors = new List<MovieActor>()
            //        {
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Will",
            //                    LastName = "Smith",
            //                },
            //            },
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Martin",
            //                    LastName = "Loruns",
            //                },
            //            },
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Vnessa",
            //                    LastName = "Hudgens",
            //                },


            //            },
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Alexander",
            //                    LastName = "Ludwig",
            //                },
            //            },
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Paola",
            //                    LastName = "Nunez",
            //                },
            //            },
            //            new MovieActor
            //            {
            //                Actor = new Actor
            //                {
            //                    FirstName = "Charles",
            //                    LastName = "Melton",
            //                },
            //            },
            //        },
            //        Genres = new List<MovieGenre>()
            //        {
            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Action",
            //                },
            //            },

            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Criminal",
            //                },
            //            },
            //        },
            //    },
            };

            //Movie movie = new Movie
            //{
            //    Title = "Bad Boys for Life",
            //    ReleaseDate = DateTime.Parse("2020/01/17"),
            //    Rate = 7.2,
            //    Minutes = 124,
            //    ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
            //    Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
            //    Country = new Country { Name = "USA" },
            //    Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
            //    MovieActors = new List<MovieActor>()
            //    {
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Will",
            //                LastName = "Smith",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Martin",
            //                LastName = "Loruns",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Vnessa",
            //                LastName = "Hudgens",
            //            },


            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Alexander",
            //                LastName = "Ludwig",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Paola",
            //                LastName = "Nunez",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Charles",
            //                LastName = "Melton",
            //            },
            //        },
            //    },
            //    Genres = new List<MovieGenre>()
            //        {
            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Action",
            //                },
            //            },

            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Criminal",
            //                },
            //            },
            //    },
            //};
            //Movie movie = new Movie
            //{
            //    Title = "Bad Boys for Life",
            //    ReleaseDate = DateTime.Parse("2020/01/17"),
            //    Rate = 7.2,
            //    Minutes = 124,
            //    ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
            //    Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
            //    Country = new Country { Name = "USA" },
            //    Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
            //    MovieActors = new List<MovieActor>()
            //    {
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Will",
            //                LastName = "Smith",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Martin",
            //                LastName = "Loruns",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Vnessa",
            //                LastName = "Hudgens",
            //            },


            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Alexander",
            //                LastName = "Ludwig",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Paola",
            //                LastName = "Nunez",
            //            },
            //        },
            //        new MovieActor
            //        {
            //            Actor = new Actor
            //            {
            //                FirstName = "Charles",
            //                LastName = "Melton",
            //            },
            //        },
            //    },
            //    Genres = new List<MovieGenre>()
            //        {
            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Action",
            //                },
            //            },

            //            new MovieGenre
            //            {
            //                Genre = new Genre
            //                {
            //                    Name = "Criminal",
            //                },
            //            },
            //        },
            //};
            //Movie movie = new Movie
            //{
            //    Title = "Bad Boys for Life",
            //    ReleaseDate = DateTime.Parse("2020/01/17"),
            //    Rate = 7.2,
            //    Minutes = 124,
            //    ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
            //    Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
            //    Country = new Country { Name = "USA" },
            //    Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
            //    MovieActors = new List<MovieActor>()
            //    {
            //        new MovieActor
            //        {

            //        },
            //        new MovieActor
            //        {

            //        },
            //        new MovieActor
            //        {



            //        },
            //        new MovieActor
            //        {

            //        },
            //        new MovieActor
            //        {

            //        },
            //        new MovieActor
            //        {

            //        },
            //    },
            //    Genres = new List<MovieGenre>()
            //        {
            //            new MovieGenre
            //            {

            //            },

            //            new MovieGenre
            //            {

            //            },
            //        },
            //};

            await dbContext.Movies.AddRangeAsync(movies);
            await dbContext.SaveChangesAsync();
        }
    }
}