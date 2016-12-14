using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class RoleUser
    {
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        //Put other property if exists
        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RoleAddTime { get; set; }
    }
}
