using Prestige_eSports.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prestige_eSports.Data.Models
{
    [Table("Profile", Schema = "User")]
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
