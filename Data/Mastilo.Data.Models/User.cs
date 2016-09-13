namespace Mastilo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class User : IdentityUser
    {
        public User()
        {
            this.Masterpieces = new HashSet<Masterpiece>();
            this.Posts = new HashSet<TimelinePost>();
            this.Comments = new HashSet<Comment>();
            this.Rates = new HashSet<Rate>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserNameCustom { get; set; }

        [Required(ErrorMessage = "Възраст задължителна!")]
        public int Age { get; set; }

        public string HomeTown { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Masterpiece> Masterpieces { get; set; }

        public virtual ICollection<TimelinePost> Posts { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public DateTime RegistrationDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}