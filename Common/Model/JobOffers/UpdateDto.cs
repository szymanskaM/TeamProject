using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.JobOffers
{
    public class UpdateJobOffersDto
    {
        public long Id { get; set; }
        public string Position { get; set; }
        public string Localization { get; set; }
        public string ContractType { get; set; }
        public string Duties { get; set; }
        public string Requirements { get; set; }
        public long? SalaryMonth { get; set; }
        public long? SalaryHour { get; set; }
        public string WorkingTime { get; set; }
        public string Tittle { get; set; }
        public string WorkMode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
