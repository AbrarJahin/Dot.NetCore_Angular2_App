using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Father { get; set; }

        public string Mother { get; set; }

        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public Profile()
        {
            //Handeling default value poperty for empty lists
            Addresses = new List<Address>();
            Experiences = new List<Experience>();
            Phones = new List<Phone>();
        }
    }
}
