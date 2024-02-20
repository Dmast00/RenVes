using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Rent
    {
        public int Rent_Id { get; set; }
        public int Rent_Id_Client { get; set; }
        public int Rent_Id_Dress { get; set; }
        public DateTime Rent_Start_Date { get; set; }
        public DateTime Rent_End_Date { get; set; }
        public string Rent_Status { get; set; }

    }
}
