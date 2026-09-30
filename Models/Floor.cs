namespace DormAPI.Models
{
    public class Floor
    {
        public int floorId { get; set; }
        public int floorNumber { get; set; }
        public int buildingId { get; set; }
        public Floor() { }
        public Floor(int floorId, int floorNumber, int buildingId)
        {
            this.floorId = floorId;
            this.floorNumber = floorNumber;
            this.buildingId = buildingId;
        }
    }
}
