using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Users
{
    public class CreateEmployerDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
    }
}
