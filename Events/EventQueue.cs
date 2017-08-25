
using System.Collections.Generic;
using System.Diagnostics;
using GaGame.GaEngine.Services.EventQueue;

public class EventQueue: IEventQueue
{
        private List<Event> events = new List<Event>();

    public EventQueue()
    {		
    }

    public void Post( Event e )
    {
        Debug.Assert( e != null );
        events.Add(e);
    }

    public Event Next() // get the next entry of the front of the queue
    {
        Event e = null;
        if( events.Count > 0 ) {
            e = events[ 0 ];
            events.RemoveAt( 0 );
        }
        return e;
    }	

    public void Deliver()
    {
        foreach( Event e in events ) {
            e.Deliver();
        }
        events.Clear();
    }
}
