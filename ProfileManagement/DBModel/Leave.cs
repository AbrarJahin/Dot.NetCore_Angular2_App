using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileManagement.DBModel
{
    public class Leave
    {
        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public string Reason { get; set; }
    }
}
