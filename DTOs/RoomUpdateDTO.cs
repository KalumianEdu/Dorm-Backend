namespace DormAPI.DTOs
{
    public class RoomUpdateDTO
    {
        public int roomId { get; set; }
        public string roomNumber { get; set; }
        public int floorId { get; set; }
        public int capacity { get; set; }
        public int availableBeds { get; set; }
        public int roomStatusId { get; set; }
    }
}
