using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Actors
{
    public class ActorInputModel
    {
        [Required(ErrorMessage = "State firstName!")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
