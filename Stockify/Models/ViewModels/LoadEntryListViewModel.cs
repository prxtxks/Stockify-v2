using System;
namespace Stockify.Models
{
    public class LoadEntryListViewModel
    {
        public string OrgName { get; set; }

        public string LoadName { get; set; }

        public string LoadGroup { get; set; }

        public List<LoadEntry> LoadEntryList { get; set;  }

        public Dictionary<string, string> LoadEntryProductNames { get; set; }

        public Dictionary<string, string> LoadEntryProductTypes { get; set; }
    }
}

