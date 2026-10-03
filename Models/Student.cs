namespace DormAPI.Models
{
    public class Student
    {
        public int studentId { get; set; }
        public string StudentNumber { get; set; } = string.Empty;
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearOfStudy { get; set; }
        public int UniversityID { get; set; }
        public string UniversityName { get; set; } = string.Empty;
        public int FacultyID { get; set; }
        public string FacultyName { get; set; } = string.Empty;
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int EducationLevelID { get; set; }
        public string EducationLevelName { get; set; } = string.Empty;

        // person fields
        public int personId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public int? NationalityID { get; set; }
        public string Nationality { get; set; } = string.Empty;

        // contact
        public int ContactID { get; set; }
        public Contact? Contact { get; set; }
    }
}
