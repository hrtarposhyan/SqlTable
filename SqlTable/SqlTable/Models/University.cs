using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTable.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DestroyDate { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{PhoneNumber}\t{Email}\t{DestroyDate}";
        }

    }
}
