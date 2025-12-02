using System;
namespace Stockify.Models
{
	public class JobWorkEntryListViewModel
	{
        public string OrgName { get; set; }

        public string JobWorkName { get; set; }

        public List<JobWorkEntry> JobWorkEntryList { get; set; }

        public Dictionary<string, string> JobWorkEntryProductNames { get; set; }

        public Dictionary<string, string> JobWorkEntryProductTypes { get; set; }
    }
}

