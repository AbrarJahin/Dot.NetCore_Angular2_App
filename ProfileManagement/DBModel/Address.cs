using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileManagement.DBModel
{
    public class Address
    {
        public int Id { get; set; }

        //Should add a Index - unique in here
        public string DetailedAddress { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}
