namespace DormAPI.Database.EF.Entities
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set;
        }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PassportNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int NationalityId { get; set; }
        public int ContactId { get; set; }

        public virtual Nationality Nationality { get; set; } = null!;


    }
}
