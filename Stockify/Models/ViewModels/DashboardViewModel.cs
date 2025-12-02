using System;
using System.ComponentModel.DataAnnotations;

namespace Stockify.Models
{
	public class DashboardViewModel
	{
        public string OrgId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<JobWork>? JobWorkList { get; set; } = new List<JobWork>();
    }
}

