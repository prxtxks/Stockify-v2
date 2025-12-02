using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Models
{
    [Table("Stocks")]
    public class Stock
    {
        [Key]
        [Required]
        public string StockId { get; set; }

        [Required]
        public string OrgId { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "The LoadGroup is required.")]
        public string LoadGroup { get; set; }

        //[Required(ErrorMessage = "The product CostPerUnitWeight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Weight { get; set; }

        //[Required(ErrorMessage = "The product CostPerUnitWeight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Quantity { get; set; }

        //[Required(ErrorMessage = "The product CostPerUnitWeight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Height { get; set; }

        //[Required(ErrorMessage = "The product CostPerUnitWeight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
        public decimal? Width { get; set; }

        [Required(ErrorMessage = "The product creation date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CreationDate { get; set; }

        public Stock()
        {
            // Generate a unique ID for the product based on current timestamp
            //LoadId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Set creation date to current date and time
            CreationDate = DateTime.Now;
        }
    }
}

