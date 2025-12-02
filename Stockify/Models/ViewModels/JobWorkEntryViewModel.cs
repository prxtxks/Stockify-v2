using System;
using System.ComponentModel.DataAnnotations;

namespace Stockify.Models
{
	public class JobWorkEntryViewModel
	{
        public string JobWorkEntryId { get; set; }

        public string JobWorkId { get; set; }

        public string JobWorkName { get; set; }

        public string JobWorkEntryOrgId { get; set; }

        public string OrgName { get; set; }

        public string JobWorkEntryProductId { get; set; }

        public string JobWorkEntryProductName { get; set; }

        public string JobWorkEntryProductType { get; set; }

        public Dictionary<string, List<Stock>> ProductStockDict { get; set; } = new Dictionary<string, List<Stock>>();

        public List<Product>? ProductList { get; set; } = new List<Product>();

        public decimal? Weight { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Height { get; set; }

        public decimal? Width { get; set; }

        public DateTime CreationDate { get; set; }
    }
}

