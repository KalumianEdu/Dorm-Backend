namespace DormAPI.DTOs
{
    public class DashboardOverviewDTO
    {
        public int TotalStudents { get; set; }
        public int TotalBeds { get; set; }
        public int StudentsWithoutRoom { get; set; }
        public int OccupiedBeds { get; set; }
        public int AvailableBeds { get; set; }
        public int TotalBuildings { get; set; }
        public int TotalRooms { get; set; }
    }
}
