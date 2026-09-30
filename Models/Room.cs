namespace DormAPI.Models
{
    public class Room
    {
        public int roomId { get; set; }
        public string roomNumber { get; set; }
        public int floorId { get; set; }
        public int capacity { get; set; }
        public int availableBeds { get; set; }
        public int roomStatusId { get; set; }

        public Room() { }
        public Room(int roomId, string roomNumber, int floorId, int capacity, int availableBeds, int roomStatusId)
        {
            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.floorId = floorId;
            this.capacity = capacity;
            this.availableBeds = availableBeds;
            this.roomStatusId = roomStatusId;
        }
    }
}
