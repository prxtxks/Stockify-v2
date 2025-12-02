using System;
namespace Stockify.Models
{
	public class OrganisationViewModel
	{
        public Organisation organisation { get; set; }

        public List<string> OrganisationTypeList { get; set; }

        public List<Organisation> OrganisationList { get; set; }
    }
}


    