using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Models
{
    [Table("Cutouts")]
    public class Cutout
    {
        [Key]
        [Required]
        public string CutoutId { get; set; }

        [Required]
        public string OrgId { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "The Cutout Quantity is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Quantity { get; set; }

        [Required(ErrorMessage = "The Cutout Height is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Height { get; set; }

        [Required(ErrorMessage = "The Cutout Width is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Width { get; set; }

        [Required(ErrorMessage = "The product creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CreationDate { get; set; }

        public Cutout()
        {
            // Set creation date to current date and time
            CreationDate = DateTime.Now;
        }
    }
}

