using MicroMachines.Common;
using System.Collections.Generic;

namespace MicroMachines.Services.Identity.Data.Models {
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
