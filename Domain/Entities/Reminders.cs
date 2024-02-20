using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Reminders
    {
        public int Reminder_Id { get; set; }
        public int Reminder_Id_Rent { get; set; }
        public string Reminder_Type { get; set; }
        public DateTime Reminder_Date_Time { get; set; }
    }
}
