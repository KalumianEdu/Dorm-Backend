using System;

namespace DormAPI.DTOs
{
    public class AddFullStudentDTO
    {
        // Contact
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public int? RelationshipTypeID { get; set; }

        // Person
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PassportNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int? NationalityID { get; set; }

        // Student
        public string StudentNumber { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearOfStudy { get; set; }
        public int UniversityID { get; set; }
        public int FacultyID { get; set; }
        public int DepartmentID { get; set; }
        public int EducationLevelID { get; set; }
    }
}
