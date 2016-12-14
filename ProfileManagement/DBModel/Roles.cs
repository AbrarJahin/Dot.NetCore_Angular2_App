using System.Collections.Generic;

namespace ProfileManagement.DBModel
{
    public class Roles
    {
        public int Id { get; set; }

        //Should add a Index - unique in here
        public string RoleName { get; set; }

        public virtual ICollection<RoleUser> RoleUsers { get; set; }

        public Roles()
        {
            this.RoleUsers = new List<RoleUser>();
        }
    }
}
