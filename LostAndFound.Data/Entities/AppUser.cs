using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound.Data.Entities
{
    public class AppUser: IdentityUser<Guid, AppUserLogin, AppUserRole, AppUserClaim>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        private string _userNameEmailBackingField;

        public override string UserName
        {
            get { return _userNameEmailBackingField; }
            set { _userNameEmailBackingField = value; }
        }

        public override string Email
        {
            get { return _userNameEmailBackingField; }
            set { _userNameEmailBackingField = value; }
        }
        [Required]
        public DateTime JoinDate { get; set; }

        public AppUser CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public AppUser()
        {
            LockoutEnabled = true;
             JoinDate = DateTime.UtcNow;
            IsActive = true;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser, Guid> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class AppUserLogin : IdentityUserLogin<Guid> { }

    public class AppUserRole : IdentityUserRole<Guid> { }

    public class AppUserClaim : IdentityUserClaim<Guid> { }

    public class AppRole : IdentityRole<Guid, AppUserRole> { }
}
