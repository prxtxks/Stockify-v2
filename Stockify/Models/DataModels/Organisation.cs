using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Models
{
    [Table("Organizations")]
    public class Organisation
    {
        [Key]
        [Required]
        public string OrgId { get; set; }

        [Required(ErrorMessage = "The organization name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The organization type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The organization location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The organization phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The organization email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The organization creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CreationDate { get; set; }

        public Organisation()
        {
            // Generate a unique ID for the organization based on current timestamp
            OrgId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Set creation date to current date and time
            CreationDate = DateTime.Now;
        }
    }
}