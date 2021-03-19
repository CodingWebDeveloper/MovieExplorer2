namespace MovieExplorer.Data.Seeding
{
    using MovieExplorer.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ActorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Actors.Any())
            {
                return;
            }

            IEnumerable<Actor> actors = new List<Actor>()
            {
                new Actor
                {
                    FirstName = "Will",
                    LastName = "Smith",
                },
                new Actor
                {
                    FirstName = "Martin",
                    LastName = "Lawrence",
                },
                new Actor
                {
                    FirstName = "Vanessa",
                    LastName = "Hudgens",
                },
                new Actor
                {
                    FirstName ="Alexander",
                    LastName= "Ludwig",
                },
                new Actor
                {
                    FirstName = "Paola",
                    LastName = "Nunez",
                },
                new Actor
                {
                    FirstName = "Charles",
                    LastName = "Melton",
                },
                new Actor
                {
                    FirstName = "Vin",
                    LastName = "Diesel",
                },
                new Actor
                {
                    FirstName ="Eiza",
                    LastName= "Gonzalez",
                },
                new Actor
                {
                    FirstName = "Sam",
                    LastName = "Heughan",
                },
                new Actor
                {
                    FirstName ="Toby",
                    LastName= "Kebbell",
                },
                new Actor
                {
                    FirstName = "Talulah",
                    LastName = "Riley",
                },
                new Actor
                {
                    FirstName ="Lamorne",
                    LastName= "Morris",
                },new Actor
                {
                    FirstName = "Robert",
                    MiddleName= "Downey",
                    LastName = "Jr",
                },
                new Actor
                {
                    FirstName ="Chris",
                    LastName= "Hemsworth",
                },
                 new Actor
                {
                    FirstName = "Mark",
                    LastName = "Ruffalo",
                },
                new Actor
                {
                    FirstName ="Chris",
                    LastName= "Evans",
                },new Actor
                {
                    FirstName = "Josh",
                    LastName = "Brolin",
                },
                new Actor
                {
                    FirstName ="Benedict",
                    LastName= "Cumberbatch",
                },
                 new Actor
                {
                    FirstName = "Scarlett",
                    LastName = "Johansson",
                },
                new Actor
                {
                    FirstName ="Eddie",
                    LastName= "Marsan",
                },new Actor
                {
                    FirstName = "Dwayne",
                    LastName = "Johnson",
                },
                new Actor
                {
                    FirstName ="Jason",
                    LastName= "Statham",
                },
                new Actor
                {
                    FirstName = "Idris",
                    LastName = "Elba",
                },
                new Actor
                {
                    FirstName ="Vanessa",
                    LastName= "Kirby",
                },new Actor
                {
                    FirstName = "Kyle",
                    LastName = "Chandler",
                },
                new Actor
                {
                    FirstName ="Vera",
                    LastName= "Farmiga",
                },
                new Actor
                {
                    FirstName = "Millie",
                    MiddleName = "Bobby",
                    LastName = "Brown",
                },
                new Actor
                {
                    FirstName ="Ken",
                    LastName= "Watanabe",
                },new Actor
                {
                    FirstName = "Sally",
                    LastName = "Hawkins",
                },
                new Actor
                {
                    FirstName ="Bradley",
                    LastName= "Whitford",
                },
                new Actor
                {
                    FirstName = "Shia",
                    LastName = "LaBeouf",
                },
                new Actor
                {
                    FirstName ="John",
                    LastName= "Malkowich",
                },new Actor
                {
                    FirstName = "Ken",
                    LastName = "Jeong",
                },
                new Actor
                {
                    FirstName ="Josh",
                    LastName= "Duhamel",
                },
                new Actor
                {
                    FirstName = "Tyrese",
                    LastName = "Gibson",
                },
                new Actor
                {
                    FirstName = "Jaeden",
                    LastName = "Lieberher",
                },new Actor
                {
                    FirstName = "Bill",
                    LastName = "Skasgard",
                },
                new Actor
                {
                    FirstName = "Jeremy",
                    MiddleName = "Ray",
                    LastName = "Taylor",
                },
                new Actor
                {
                    FirstName = "Sopthia",
                    LastName = "Lillis",
                },
                new Actor
                {
                    FirstName = "Finn",
                    LastName = "Wolhard",
                },
                new Actor
                {
                    FirstName = "Jake",
                    MiddleName = "Dylan",
                    LastName = "Grazer",
                },
                new Actor
                {
                    FirstName = "Alexandra",
                    MiddleName = "Maria",
                    LastName = "Lara",
                },
                new Actor
                {
                    FirstName = "Ulrich",
                    LastName = "Matthes",
                },
                new Actor
                {
                    FirstName = "Bruno",
                    LastName = "Ganz",
                },
                new Actor
                {
                    FirstName = "Christian",
                    LastName = "Bale",
                },
                new Actor
                {
                    FirstName = "Heath",
                    LastName = "Ledger",
                },
                new Actor
                {
                    FirstName = "Aaron",
                    LastName = "Eckhart",
                },
                new Actor
                {
                    FirstName = "Gary",
                    LastName = "Oldman",
                },
                new Actor
                {
                    FirstName = "Frances",
                    LastName = "Fisher",
                },
                new Actor
                {
                    FirstName = "Kathy",
                    LastName = "Bates",
                },
                new Actor
                {
                    FirstName = "Billy",
                    LastName = "Zane",
                },
                new Actor
                {
                    FirstName = "Zach",
                    LastName = "Aguilar",
                },
                new Actor
                {
                    FirstName = "Bryce",
                    LastName = "Papenbrook",
                },
                new Actor
                {
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                },
                new Actor
                {
                    FirstName = "Kate",
                    LastName = "Winslet",
                },
                new Actor
                {
                    FirstName = "Brad",
                    LastName = "Pitt",
                },
                new Actor
                {
                    FirstName = "Margot",
                    LastName = "Robble",
                },
                new Actor
                {
                    FirstName = "Emile",
                    LastName = "Hirsch",
                },
                new Actor
                {
                    FirstName = "Charles",
                    LastName = "Dance",
                },
                new Actor
                {
                    FirstName = "Corey",
                    LastName = "Hawkins",
                },
                new Actor
                {
                    FirstName = "Samuel",
                    MiddleName = "L.",
                    LastName = "Weaver",
                },
                new Actor
                {
                    FirstName = "Tom",
                    LastName = "Hiddleston",
                },
                new Actor
                {
                    FirstName = "Brie",
                    LastName = "Larson",
                },
                new Actor
                {
                    FirstName = "John",
                    LastName = "Reilly",
                },
                new Actor
                {
                   FirstName = "John",
                   LastName = "Goodman",
                },
                new Actor
                {
                   FirstName = "Patrick",
                   LastName = "Wilson",
                },
                new Actor
                {
                    FirstName = "Ron",
                    LastName = "Livingston",
                },
            };

            await dbContext.Actors.AddRangeAsync(actors);
            await dbContext.SaveChangesAsync();
        }
    }
}
