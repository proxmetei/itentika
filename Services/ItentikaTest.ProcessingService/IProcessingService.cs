using ItentikaTest.Models;

namespace ItentikaTest.Services.Processing
{
    public interface IProcessingService
    {
        void processEvent(Event curEvent);
    }
}
