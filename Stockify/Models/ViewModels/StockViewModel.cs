using System;
namespace Stockify.Models.ViewModels
{
	public class StockViewModel
	{
        public string StockId { get; set; }
        public string StockOrgId { get; set; }
        public string OrgName { get; set; }
        public string LoadGroup { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }

        public List<Product>? ProductList { get; set; }
    }
}

