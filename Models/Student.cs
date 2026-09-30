namespace DormAPI.Models
{
    public class Student : Person
    {
        public int studentId { get; set; }
        public string StudentNumber { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearOfStudy { get; set; }
        public int UniversityID { get; set; }
        public String UniversityName { get; set; }
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int EducationLevelID { get; set; }
        public string EducationLevelName { get; set; }
        // New: optional RoomAllocationID for assigned bed reference
        public int? RoomAllocationID { get; set; }
    }
}
