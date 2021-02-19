using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Directors
{
    public class DirectorInputModel
    {
        [Required(ErrorMessage = "State firstName")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
