using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTable.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Age}\t{PhoneNumber}\t{Address}\t{Email}";
        }
    }
}
