using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class CommentServiceTests
    {
        public CommentServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CheckCreateComments()
        {
            ICollection<Comment> comments = new List<Comment>();
            CommentInputViewModel firstCommentInputModel = new CommentInputViewModel
            {
                MovieId = 1,
                UserId = "user1",
                Text = "some text",
            };

            CommentInputViewModel secondCommentInputViewModel = new CommentInputViewModel
            {
                MovieId = 1,
                UserId = "user1",
                Text = "some text",
            };

            Mock<IDeletableEntityRepository<Comment>> mockComment = new Mock<IDeletableEntityRepository<Comment>>();
            Mock<IDeletableEntityRepository<ApplicationUser>> mockUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            mockComment.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                .Callback((Comment comment) => comments.Add(comment));

            ICommentService commentService = new CommentService(null, mockComment.Object, null);

            await commentService.AddComment(firstCommentInputModel);
            await commentService.AddComment(secondCommentInputViewModel);

            Assert.Equal(2, comments.Count());
        }

        public IEnumerable<Comment> GetData()
        {
            return new List<Comment>()
            {
                new Comment
                {
                   Id = 1,
                   User = new ApplicationUser
                   {
                       Id = "user 1",
                       UserName = "user1",
                   },
                   UserId = "user 1",
                   Movie = new Movie
                   {
                       Id = 1,
                       Title = "some title",
                       ReleaseDate = DateTime.UtcNow,
                       Minutes = 123,
                       ImageUrl = "image url",
                       Trailer = "trailer url",
                       Description = "desription info",
                       Director = new Director
                       {
                           Id = 1,
                           FirstName = "director firstName",
                           LastName = "director lastName",
                       },
                       DirectorId = 1,
                       Rate = 1,
                       Country = new Country
                       {
                           Id = 1,
                           Name = "USA",
                       },
                       CountryId = 1,
                   },
                   MovieId = 1,
                   Text = "Text of the comment",
                   CreatedOn = DateTime.UtcNow,
                },
                new Comment
                {
                   Id = 2,
                   Movie = new Movie
                   {
                       Id = 1,
                       Title = "some title",
                       ReleaseDate = DateTime.UtcNow,
                       Minutes = 123,
                       ImageUrl = "image url",
                       Trailer = "trailer url",
                       Description = "desription info",
                       Director = new Director
                       {
                           Id = 1,
                           FirstName = "director firstName",
                           LastName = "director lastName",
                       },
                       DirectorId = 1,
                       Rate = 1,
                       Country = new Country
                       {
                           Id = 1,
                           Name = "USA",
                       },
                       CountryId = 1,
                   },
                   Text = "some text",
                   UserId = "user 1",
                   CreatedOn = DateTime.UtcNow,
                },
            };
        }

        [Fact]
        public void CheckForGettingAllComments()
        {
            IEnumerable<Comment> expectedComments = this.GetData().Where(x => x.MovieId == 1);
            Mock<IDeletableEntityRepository<Comment>> mockComments = new Mock<IDeletableEntityRepository<Comment>>();
            mockComments.Setup(x => x.All()).Returns(expectedComments.AsQueryable());

            ICommentService commentService = new CommentService(null, mockComments.Object, null);

            IEnumerable<CommentViewModel> actualComments = commentService.GetAllCommentsOfMovie(1).ToArray();

            Assert.Equal(expectedComments.Count(), actualComments.Count());
        }
    }
}
