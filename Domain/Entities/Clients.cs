using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clients
    {
        public int Client_id { get; set; }
        public string Client_Name { get; set; }
        public string Client_LastName { get; set; }
        public string Client_PhoneNumber { get; set; }
        public string Client_Email { get; set; }
        public DateTime Client_Register_Date { get; set; }

    }
}
