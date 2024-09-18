namespace ItentikaTest.Models
{
    public class Event : BaseEntity
    {
        public EventTypeEnum Type { get; set; }
        public DateTime Time { get; set; }
        public override string ToString()
        {
            return $"Id: {Id},Type: {(int)Type},Time: {Time}";
        }
    }
}
