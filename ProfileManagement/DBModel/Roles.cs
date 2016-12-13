using System.Collections.Generic;

namespace ProfileManagement.DBModel
{
    public class Roles
    {
        public int Id { get; set; }

        //Should add a Index - unique in here
        public string RoleName { get; set; }

        public List<RoleUser> RoleUsers { get; set; }
        /*
        public virtual ICollection<Users> Users { get; set; }

        public Roles()
        {
            this.Users = new List<Users>();
        }
        */
    }
}
