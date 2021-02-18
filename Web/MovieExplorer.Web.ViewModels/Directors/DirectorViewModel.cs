using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Directors
{
    public class DirectorViewModel : IMapFrom<Director>
    {

        public int DirectorId { get; set; }

        public string DirectorName { get; set; }
    }
}
