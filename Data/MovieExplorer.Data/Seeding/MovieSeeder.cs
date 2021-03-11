﻿using MovieExplorer.Data.Models;
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
                new Movie
                {
                 Title = "Bloodshot",
                 ReleaseDate = DateTime.Parse("2020/03/13"),
                 Rate = 5.7,
                 Minutes = 109,
                 ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585130363/thumbs/themoviedb-1585130363-poster.jpg",
                 Trailer = "https://www.youtube.com/embed/vOUVVDWdXbo",
                 Description = "Bloodshot is a 2020 American superhero film based on the Valiant Comics character of the same name. " +
                 "It is intended to be the first installment in a series of films set within a Valiant Comics shared cinematic universe." +
                 " Directed by David S. F. Wilson (in his feature directorial debut) from a screenplay by Jeff Wadlow and Eric Heisserer and a story by Wadlow, the film stars Vin Diesel, Eiza González, Sam Heughan, Toby Kebbell, and Guy Pearce." +
                 " It follows a Marine who was killed in action, only to be brought back to life with superpowers by an organization that wants to use him as a weapon.",
                 Country = dbContext.Countries.FirstOrDefault(x => x.Name == "USA"),
                 Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
                 MovieActors = new List<MovieActor>()
                 {
                    new MovieActor
                    {
                         Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Sam" && x.LastName == "Heughan"),
                    },
                    new MovieActor
                    {
                        Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Vin" && x.LastName == "Diesel"),
                    },
                    new MovieActor
                    {
                         Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Eiza" && x.LastName == "Gonzalez"),
                    },
                    new MovieActor
                    {
                         Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Toby" && x.LastName == "Kebbell"),
                    },
                    new MovieActor
                    {
                       Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Talulah" && x.LastName == "Riley"),
                    },
                    new MovieActor
                    {
                        Actor = dbContext.Actors.FirstOrDefault(x => x.FirstName == "Lamorne" && x.LastName == "Morris"),
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
                        Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Science Fiction"),
                    },
                    new MovieGenre
                    {
                        Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Drama"),
                    },
                 },
                },

                new Movie
                {
                    Title = "Avengers: Infinity War",
                    ReleaseDate = DateTime.Parse("2018/04/27"),
                    Rate = 9.0,
                    Minutes = 149,
                    ImageUrl = "https://filmisub.com/uploads/posts/zamunda/535884/thumbs/535884-poster.jpg",
                    Trailer = "https://www.youtube.com/embed/6ZfuNTqbHE8",
                    Description = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                    Country = dbContext.Countries.FirstOrDefault(x => x.Name == "USA"),
                    Director = new Director { FirstName = "Russo ", LastName = "Brothers" },
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
                        Actor =dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Mark" && x.LastName == "Ruffalo"),
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
                //{
                //      Title = "Miami detectives Mike Lowrey and Marcus Burnett must face off against a mother-and-son pair of drug lords who wreak vengeful havoc on their city.",
                //      ReleaseDate = DateTime.Parse("2020/01/17"),
                //      Rate = 7.2,
                //      Minutes = 124,
                //      ImageUrl = "https://filmisub.com/uploads/posts/zamunda/themoviedb-1585322934/thumbs/themoviedb-1585322934-poster.jpg",
                //      Trailer = "https://www.youtube.com/embed/jKCj3XuPG8M",
                //      Country = new Country { Name = "USA" },
                //      Director = new Director { FirstName = "Edi ", LastName = "El Abri" },
                //      MovieActors = new List<MovieActor>()
                //      {
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Will" && x.LastName=="Smith"),
                //        },
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Martin" && x.LastName=="Loruns"),
                //        },
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Vanessa" && x.LastName=="Hudgens"),
                //        },
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Alexander" && x.LastName=="Ludwig"),
                //        },
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Paola" && x.LastName=="Nunez"),
                //        },
                //        new MovieActor
                //        {
                //            Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Charles" && x.LastName=="Melton"),
                //        },
                //      },
                //      Genres = new List<MovieGenre>()
                //      {
                //        new MovieGenre
                //        {
                //           Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                //        },

                //        new MovieGenre
                //        {
                //           Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Criminal"),
                //        },
                //      },
                //},


                //new Movie
                //{
                //    Title = "Avengers: Endgame",
                //    ReleaseDate = DateTime.Parse("2019/04/26"),
                //    Rate = 9,
                //    Minutes = 182,
                //    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                //    Trailer = "https://www.youtube.com/embed/TcMBFSGVi1c",
                //    Description = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                //    Country = new Country { Name = "USA" },
                //    Director = new Director { FirstName = "Russo ", LastName = "Brothers" },
                //    MovieActors = new List<MovieActor>()
                //    {
                //       new MovieActor
                //       {
                //          Actor =dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Robert" && x.LastName == "Jr" ),
                //       },
                //       new MovieActor
                //       {
                //         Actor =dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Mark" && x.LastName == "Ruffalo"),
                //       },
                //       new MovieActor
                //       {
                //         Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Chris" && x.LastName=="Evans"),
                //       },
                //       new MovieActor
                //       {
                //         Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName=="Benedict" && x.LastName=="Cumberbatch"),
                //       },
                //       new MovieActor
                //       {
                //          Actor = dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Josh" && x.LastName == "Brolin"),
                //       },
                //       new MovieActor
                //       {
                //         Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Chris" && x.LastName == "Hemsworth"),
                //       },
                //    },
                //    Genres = new List<MovieGenre>()
                //    {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                //        },

                //        new MovieGenre
                //        {
                //           Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Adventure"),
                //        },
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Fantasy"),
                //        },
                //    },
                //},

                //new Movie
                //{
                //     Title = "Kong: Skull Island",
                //     ReleaseDate = DateTime.Parse("2017/03/10"),
                //     Rate = 8.4,
                //     Minutes = 182,
                //     ImageUrl = "http://static1.squarespace.com/static/59525610e4fcb5c94e4a3187/t/597bb466bf629a536f884b54/1501279338565/?format=1500w",
                //     Trailer = "https://www.youtube.com/embed/44LdLqgOpjo",
                //     Description = "After the Vietnam war, a team of scientists explores an uncharted island in the Pacific, venturing into the domain of the mighty Kong, and must fight to escape a primal Eden.",
                //     Country = new Country { Name = "USA" },
                //     Director = new Director { FirstName = "Jordan ", LastName = "Vogt-Roberts" },
                //     MovieActors = new List<MovieActor>()
                //     {
                //        new MovieActor
                //        {
                //           Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Samuel" && x.MiddleName == "L." && x.LastName == "Weaver"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Tom" && x.LastName == "Hiddleston"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Brie" && x.LastName == "Larson"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "John" && x.LastName == "Reilly"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "John" && x.LastName == "Goodman"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Corey" && x.LastName == "Hawkins"),
                //        },
                //     },
                //     Genres = new List<MovieGenre>()
                //     {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Adventure"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Science Fiction"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                //        },
                //     },
                //},

                //new Movie
                //{
                //     Title = "Godzilla: King of the Monsters",
                //     ReleaseDate = DateTime.Parse("2019/05/13"),
                //     Rate = 7,
                //     Minutes = 122,
                //     ImageUrl = "https://img.over-blog-kiwi.com/3/58/82/27/20190818/ob_7fc451_fq40gmfm4p03txwmxqqkh2ccbw4.jpg",
                //     Trailer = "https://www.youtube.com/embed/QFxN2oDKk0E",
                //     Description = "The crypto-zoological agency Monarch faces off against a battery of god-sized monsters, including the mighty Godzilla, who collides with Mothra, Rodan, and his ultimate nemesis, the three-headed King Ghidorah.",
                //     Country = new Country { Name = "USA" },
                //     Director = new Director { FirstName = "Michael ", LastName = "Dougherty" },
                //     MovieActors = new List<MovieActor>()
                //     {
                //        new MovieActor
                //        {
                //           Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Millie" && x.MiddleName == "Bobby" && x.LastName == "Brown"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Vera" && x.LastName == "Farmiga"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Kyle" && x.LastName == "Chandler"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Ken" && x.LastName == "Watanabe"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Charles" && x.LastName == "Dance"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Corey" && x.LastName == "Hawkins"),
                //        },
                //     },
                //     Genres = new List<MovieGenre>()
                //     {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Science Fiction"),
                //        },
                //     },
                //},

                //new Movie
                //{
                //     Title = "Once Upon a Time in Hollywood",
                //     ReleaseDate = DateTime.Parse("2019/07/24"),
                //     Rate = 7.6,
                //     Minutes = 160,
                //     ImageUrl = "https://m.media-amazon.com/images/M/MV5BOTg4ZTNkZmUtMzNlZi00YmFjLTk1MmUtNWQwNTM0YjcyNTNkXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_UY1200_CR90,0,630,1200_AL_.jpg",
                //     Trailer = "https://www.youtube.com/embed/ELeMaP8EPAA  ",
                //     Description = "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.",
                //     Country = new Country { Name = "USA" },
                //     Director = new Director { FirstName = "Quentin ", LastName = "Tarantino" },
                //     MovieActors = new List<MovieActor>()
                //     {
                //        new MovieActor
                //        {
                //           Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Brad" && x.LastName == "Pitt"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Leonardo" && x.LastName == "DiCaprio"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Margot" && x.LastName == "Robble"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Emile" && x.LastName == "Hirsch"),
                //        },
                //     },
                //     Genres = new List<MovieGenre>()
                //     {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Comedy"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Drama"),
                //        },
                //     },
                //},

                //new Movie
                //{
                //     Title = "Titanic",
                //     ReleaseDate = DateTime.Parse("2019/07/24"),
                //     Rate = 7.8,
                //     Minutes = 180,
                //     ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UY1200_CR88,0,630,1200_AL_.jpg",
                //     Trailer = "https://www.youtube.com/embed/kVrqfYjkTdQ",
                //     Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                //     Country = new Country { Name = "USA" },
                //     Director = new Director { FirstName = "James ", LastName = "Cameron" },
                //     MovieActors = new List<MovieActor>()
                //     {
                //        new MovieActor
                //        {
                //           Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Leonardo" && x.LastName == "DiCaprio"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Kate" && x.LastName == "Winslet"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Billy" && x.LastName == "Zane"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Kathy" && x.LastName == "Bates"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Frances" && x.LastName == "Fisher"),
                //        },
                //     },
                //     Genres = new List<MovieGenre>()
                //     {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Romantic"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Drama"),
                //        },
                //     },
                //},

                //new Movie
                //{
                //     Title = "Kimetsu no Yaiba the Movie: Mugen Train",
                //     ReleaseDate = DateTime.Parse("2020/10/16"),
                //     Rate = 7.8,
                //     Minutes = 120,
                //     ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzY1MWExOWUtZTNjMC00MzY2LWIxYTYtNjZjNThhNDBjNTZlXkEyXkFqcGdeQXVyODEyMDIxNDY@._V1_.jpg",
                //     Trailer = "https://www.youtube.com/embed/ATJYac_dORw",
                //     Description = "After his family was brutally murdered and his sister turned into a demon, Tanjiro Kamado's journey as a demon slayer began." +
                //     " Tanjiro and his comrades embark on a new mission aboard the Mugen Train, on track to despair.",
                //     Country = new Country { Name = "Japan" },
                //     Director = new Director { FirstName = "Haruo ", LastName = "Sotozaki" },
                //     MovieActors = new List<MovieActor>()
                //     {
                //        new MovieActor
                //        {
                //           Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Bryce" && x.LastName == "Papenbrook"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Zach" && x.LastName == "Aguilar"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Billy" && x.LastName == "Zane"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Kathy" && x.LastName == "Bates"),
                //        },
                //        new MovieActor
                //        {
                //          Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Frances" && x.LastName == "Fisher"),
                //        },
                //     },
                //     Genres = new List<MovieGenre>()
                //     {
                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Animation"),
                //        },

                //        new MovieGenre
                //        {
                //            Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Fantasy"),
                //        },
                //     },
                //},

            //    new Movie
            //    {
            //         Title = "The Dark Knight",
            //         ReleaseDate = DateTime.Parse("2008/07/25"),
            //         Rate = 9,
            //         Minutes = 152,
            //         ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91ebheNmoUL._RI_.jpg",
            //         Trailer = "https://www.youtube.com/embed/EXeTwQWrcwY",
            //         Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            //         Country = new Country { Name = "Japan" },
            //         Director = new Director { FirstName = "Christopher ", LastName = "Nolan" },
            //         MovieActors = new List<MovieActor>()
            //         {
            //            new MovieActor
            //            {
            //               Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Christian" && x.LastName == "Bale"),
            //            },
            //            new MovieActor
            //            {
            //              Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Heath" && x.LastName == "Ledger"),
            //            },
            //            new MovieActor
            //            {
            //              Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Aaron" && x.LastName == "Eckhart"),
            //            },
            //            new MovieActor
            //            {
            //              Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Gary" && x.LastName == "Oldman"),
            //            },
            //         },
            //         Genres = new List<MovieGenre>()
            //         {
            //            new MovieGenre
            //            {
            //                Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
            //            },

            //            new MovieGenre
            //            {
            //                Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Animation"),
            //            },
            //         },
            //    },

            //    new Movie
            //    {
            //         Title = "Downfall",
            //         ReleaseDate = DateTime.Parse("2004/04/8"),
            //         Rate = 9,
            //         Minutes = 156,
            //         ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91ebheNmoUL._RI_.jpg",
            //         Trailer = "https://www.youtube.com/embed/EXeTwQWrcwY",
            //         Description = "Traudl Junge, the final secretary for Adolf Hitler, tells of the Nazi dictator's final days in his Berlin bunker at the end of WWII.",
            //         Country = new Country { Name = "Germany" },
            //         Director = new Director { FirstName = "Oliver ", LastName = "Hirschbiegel" },
            //         MovieActors = new List<MovieActor>()
            //         {
            //            new MovieActor
            //            {
            //               Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Bruno" && x.LastName == "Ganz"),
            //            },
            //            new MovieActor
            //            {
            //              Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Alexandra" && x.MiddleName == "Maria" && x.LastName == "Lara"),
            //            },
            //            new MovieActor
            //            {
            //              Actor=dbContext.Actors.FirstOrDefault(x=>x.FirstName == "Ulrich" && x.LastName == "Matthes"),
            //            },
            //         },
            //         Genres = new List<MovieGenre>()
            //         {
            //            new MovieGenre
            //            {
            //                Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Drama"),
            //            },

            //            new MovieGenre
            //            {
            //                Genre = dbContext.Genres.FirstOrDefault(x => x.Name == "Action"),
            //            },
            //         },
            //    },
            };

            await dbContext.Movies.AddRangeAsync(movies);
            await dbContext.SaveChangesAsync();
        }
    }
}