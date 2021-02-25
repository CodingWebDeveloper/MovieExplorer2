using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Services.Data
{
    public interface IActorService
    {
        IEnumerable<SelectListItem> GetAllActors();
    }
}
