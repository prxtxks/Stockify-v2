using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    [Table("Products")]
    public class Product
	{            
            [Key]
            [Required]
            public string ProductId { get; set; }

            [Required]
            public string OrgId { get; set; }

            [Required(ErrorMessage = "The product name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "The product type is required.")]
            public string Type { get; set; }

            //[Required(ErrorMessage = "The product CostPerUnitWeight is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
            public decimal? CostPerUnitWeight { get; set; }

            //[Required(ErrorMessage = "The product CostPerUnit is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
            public decimal? CostPerUnit { get; set; }

            //[Required(ErrorMessage = "The product WeightPerUnit is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "The weight must be greater than or equal to 0.")]
            public decimal? WeightPerUnit { get; set; }

            //[Required(ErrorMessage = "The product CostPer100Sqft is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "The cost price must be greater than or equal to 0.")]
            public decimal? CostPer100Sqft { get; set; }

            //[Required(ErrorMessage = "The product WeightPer100Sqft is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "The weight must be greater than or equal to 0.")]
            public decimal? WeightPer100Sqft { get; set; }

            [Required(ErrorMessage = "The product creation date is required.")]
            [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
            public DateTime CreationDate { get; set; }

            public Product()
            {
                // Generate a unique ID for the product based on current timestamp
                ProductId = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                // Set creation date to current date and time
                CreationDate = DateTime.Now;
            }
    }
}


