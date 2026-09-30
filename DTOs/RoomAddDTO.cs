namespace DormAPI.DTOs
{
    public class RoomAddDTO
    {
        public string roomNumber { get; set; }
        public int floorId { get; set; }
        public int capacity { get; set; }
        public int roomStatusId { get; set; }
    }
}
