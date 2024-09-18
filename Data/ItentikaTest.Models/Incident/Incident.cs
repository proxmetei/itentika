namespace ItentikaTest.Models
{
    public class Incident : BaseEntity
    {
        public IncidentTypeEnum Type { get; set; }
        public DateTimeOffset Time { get; set; }
        public List<Event> Events { get; set; }
        public override string ToString()
        {
            return $"Id: {Id},Type: {(int)Type},Time: {Time}";
        }
    }
}
