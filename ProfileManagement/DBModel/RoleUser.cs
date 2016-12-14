using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class RoleUser
    {
        public virtual int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }

        //Put other property if exists
        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RoleAddTime { get; set; }
    }
}
