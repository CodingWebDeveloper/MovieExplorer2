// ReSharper disable VirtualMemberCallInConstructor
namespace MovieExplorer.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MovieExplorer.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Comments = new HashSet<Comment>();
            this.Movies = new HashSet<MovieUser>();
        }


        //public string FirstName { get; set; }

        //public string MiddleName { get; set; }

        //public string LastName { get; set; }

        //Hides inherited member. Email No need to add this property!
        //public string Email { get; set; }

        //public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<MovieUser> Movies { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
