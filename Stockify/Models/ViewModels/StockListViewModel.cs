using System;
namespace Stockify.Models
{
	public class StockListViewModel
	{
        public string OrgName { get; set; }

        public List<Stock>? StockList { get; set; }

        public Dictionary<string, string> StockProductNames { get; set; }

        public Dictionary<string, string> StockProductTypes { get; set; }
    }
}

