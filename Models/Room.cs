namespace DormAPI.Models
{
    public class Room
    {
        public int? roomId { get; set; }
        public string roomNumber { get; set; } = string.Empty;
        public int floorId { get; set; }
        public int capacity { get; set; }
        public int roomStatusId { get; set; }
        public int availableBeds { get; set; }
    }
}
