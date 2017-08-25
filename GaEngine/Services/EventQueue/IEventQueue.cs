namespace GaGame.GaEngine.Services.EventQueue
{
    public interface IEventQueue
    {
        void Post(Event e);
        Event Next();
        void Deliver();
    }
}