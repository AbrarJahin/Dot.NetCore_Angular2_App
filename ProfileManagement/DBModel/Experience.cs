using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class Experience
    {
        public int Id { get; set; }
        //Should add a Index - unique in here
        public string Company { get; set; }

        public int YearOfExperience { get; set; }

        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleasingDate { get; set; }

        public string ReasonOfLeaving { get; set; }

        //This 2 should be in seperate table for one to many relationship - now it is here for making it simple
        public string ProjectList { get; set; }

        public string TechnologiesUsed { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}
