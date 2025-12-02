using System;
namespace Stockify.Models
{
	public class JobWorkViewModel
	{
	    public string JobWorkId { get; set; }

        public string JobWorkOrgId { get; set; }

        public string OrgName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LoadGroup { get; set; }

        public List<string>? LoadGroupList { get; set; }

        public string Status { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerGSTIN { get; set; }

        public string CustomerPAN { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? CompletionDate { get; set; }
		
	}
}

