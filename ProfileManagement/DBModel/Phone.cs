using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class Phone
    {
        public int Id { get; set; }

        //Should add a Index - unique in here
        public string Number { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}
