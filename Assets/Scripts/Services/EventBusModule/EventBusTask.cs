using System.Threading.Tasks;

namespace Services.EventBusService
{
    public delegate Task EventBusTask(EventBusArgs args);
}