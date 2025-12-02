using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Models
{
    [Table("JobWorks")]
    public class JobWork
    {
        [Key]
        [Required]
        public string JobWorkId { get; set; }

        [Required]
        public string OrgId { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Load Group is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string LoadGroup { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string CustomerGSTIN { get; set; }

        [Required(ErrorMessage = "The VehicleNo is required.")]
        public string CustomerPAN { get; set; }

        [Required(ErrorMessage = "The product creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CreationDate { get; set; }

        //[Required(ErrorMessage = "The product creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime? CompletionDate { get; set; }

        public JobWork()
        {
            // Generate a unique ID for the product based on current timestamp
            //LoadId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            Status = "Open";

            // Set creation date to current date and time
            CreationDate = DateTime.Now;
        }
    }
}

