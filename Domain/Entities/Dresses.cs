using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Dresses
    {
        public int Dress_Id { get; set; }
        public string Dress_Description { get; set; }
        public string Dress_Short_Description { get; set; }
        public string Dress_Size { get; set; }
        public string Dress_Color { get; set; }
        public string Dress_Style { get; set; }
        public bool Dress_Is_Available { get; set; }

    }
}
