using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.JobOffers
{
    public class SearchOffersDto
    {
        public string Position { get; set; }
        public string? ContractType { get; set; }
        public string? WorkingTime { get; set; }
        public string? WorkMode { get; set; }
    }
}
