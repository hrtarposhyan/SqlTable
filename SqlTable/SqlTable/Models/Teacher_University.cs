using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTable.Models
{
    class Teacher_University
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int UniversityId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Hour { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{TeacherId}\t{UniversityId}\t{StartDate}\t{EndDate}\t{Hour}";
        }
    }
}
