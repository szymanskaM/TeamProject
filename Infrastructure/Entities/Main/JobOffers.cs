using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities.Main
{
    public class JobOffers
    {
        [Key]
        public long Id { get; set; }
        public long EmployerId { get; set; }
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
        public DateTime PostDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}
