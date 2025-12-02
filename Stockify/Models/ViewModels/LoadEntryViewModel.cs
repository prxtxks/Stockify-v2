using System;
namespace Stockify.Models
{
	public class LoadEntryViewModel
	{
        public string LoadId { get; set; }
        public string LoadName { get; set; }
        public string LoadOrgId { get; set; }
        public string LoadOrgName { get; set; }
        public string LoadGroup { get; set; }
        public string LoadEntryProductId { get; set; }
        public string LoadEntryProductName { get; set; }
        public string LoadEntryProductType { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }

        public List<Product>? ProductList { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

