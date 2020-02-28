using SqlTable.Attributes;

namespace SqlTable.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public byte Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int? UniversityId { get; set; }

        [Ignore]
        public University university { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{PhoneNumber}\t{Age}\t{Gender}\t{Email}\t{UniversityId}";
        }

    }
}
