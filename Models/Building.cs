namespace DormAPI.Models
{
    public class Building
    {
        public int buildingId { get; set; }
        public string buildingName { get; set; }

        public Building() { }
        public Building(int buildingId, string buildingName)
        {
            this.buildingId = buildingId;
            this.buildingName = buildingName;
        }
    }
}
