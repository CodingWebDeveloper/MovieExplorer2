using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IGenreService
    {
        Task CreateGenre(string genreName);

        IEnumerable<SelectListItem> GetAllGenres();
    }
}
