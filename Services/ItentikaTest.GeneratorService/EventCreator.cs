using ItentikaTest.Models;

namespace ItentikaTest.Services.Generate
{
    public static class EventCreator
    {
        public static Event GenerateEvent()
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                Type = (EventTypeEnum)new Random().Next(0, 4),
                Time = DateTime.Now
            };
        }
        public static Event GenerateEvent(int type)
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                Type = (EventTypeEnum)type,
                Time = DateTime.Now
            };
        }
    }
}
