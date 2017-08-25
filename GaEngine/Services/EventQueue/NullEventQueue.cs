namespace GaGame.GaEngine.Services.EventQueue
{
    public class NullEventQueue : IEventQueue
    {
        public void Post(Event e){}

        public Event Next()
        {
            return null;
        }

        public void Deliver(){}
    }
}