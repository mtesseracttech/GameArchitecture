using System;
using GaGame.GameObjects;

namespace GaGame.Events
{
    class PickupEvent : Event
    {
        public static EventHandler<PickupEvent> Handlers;
	
        public readonly GameObject Pickup;
	
        public PickupEvent( GameObject pPickup ) 
        {
            Pickup = pPickup;
        }

        public static void Add( EventHandler<PickupEvent> pHandler )
        {
            Handlers += pHandler;
        }
	
        public override void Deliver() // delivers itself as 
        {
            if( Handlers != null ) Handlers( this, this );
        }
    }
}