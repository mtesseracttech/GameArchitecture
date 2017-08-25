using System;

public abstract class Event
{
    public static void Add( EventHandler<Event> pHandler ) {}
	
    public abstract void Deliver();
}