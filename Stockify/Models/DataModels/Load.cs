using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Models
{
    [Table("Loads")]
    public class Load
	{
        [Key]
        [Required]
        public string LoadId { get; set; }

        [Required]
        public string OrgId { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Load Group is required.")]
        public string LoadGroup { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string VehicleNo { get; set; }

        [Required(ErrorMessage = "The product creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CreationDate { get; set; }

        public Load()
        {
            // Generate a unique ID for the product based on current timestamp
            //LoadId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Set creation date to current date and time
            CreationDate = DateTime.Now;
        }
    }
}

