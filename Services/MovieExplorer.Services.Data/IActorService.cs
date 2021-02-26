using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IActorService
    {
        Task CreateActor(string firstName, string middleName, string lastName);

        IEnumerable<SelectListItem> GetAllActors();
    }
}
