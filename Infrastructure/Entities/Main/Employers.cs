using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities.Main
{
    public class Employers
    {
        [Key]
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
    }
}
