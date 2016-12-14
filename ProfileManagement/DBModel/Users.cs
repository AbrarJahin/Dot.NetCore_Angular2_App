using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class Users
    {
        //User Table is different than Profile (they have 1-1 relation) because profile part is accessable by all and can by updated by many but this part can be updated by only user
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        public virtual ICollection<RoleUser> RoleUsers { get; set; }

        public Users()
        {
            this.RoleUsers = new List<RoleUser>();
        }
    }
}
