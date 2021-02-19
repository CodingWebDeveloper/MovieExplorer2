using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IDirectorService
    {
        Task CreateDirector(string firstName, string lastName);

        IEnumerable<SelectListItem> GetAllItems();
    }
}
