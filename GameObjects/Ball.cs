using System;
using System.Drawing;
using System.Windows.Forms;
using GaGame.GameObjects;


public class Ball : Sprite
{
	private Vec2 _velocity;
	private bool _pausing = true;
	
	public readonly Vec2 Speed = new Vec2( 10.0f, 10.0f );
	
	public Ball(string name, Vec2 position, string imageFile) : base(name, position, imageFile)
	{
		_velocity = new Vec2( 0.0f, 0.0f );
		Reset(); // sets pos and vel
	}
	
	public void Update()
	{
		// input
		if( Input.Key.Enter( Keys.P ) ) {
			_pausing = ! _pausing; // toggle
			Console.WriteLine( "Pausing "+_pausing );
		}
		
		// move
		if( ! _pausing ) {
			_position.Add( _velocity );
		}
		
		// collisions & resolve

		// Y bounds reflect
		if( _position.Y < 0 ) { 
			_position.Y = 0;
			_velocity.Y = -_velocity.Y;
		}
		if( _position.Y > 480-16 ) { // note: non maintainable literals here, who did this
			_position.Y = 480-16;
			_velocity.Y = -_velocity.Y;
		}
		
		// see game and paddles
	}

	public bool Intersects( Vec2 otherPosition, Vec2 otherSize ) {
		return
		    _position.X < otherPosition.X+otherSize.X && _position.X + Size.X > otherPosition.X &&
		    _position.Y < otherPosition.Y+otherSize.Y && _position.Y + Size.Y > otherPosition.Y;
	}
	
	public void Boost() {
		_velocity = _velocity * 2.0f;
	}

	public void DeBoost() {
		_velocity = _velocity / 2.0f;
	}
	
	public void Reset() 
	{
		_position.X = 320-8;
		_position.Y = 240-8;
		_velocity.X = Speed.X;
		_velocity.Y = (float)(Game.Random.NextDouble() - 0.5) * 2.0f * Speed.Y;
		_pausing = true;
		Time.Timeout( "Reset", 1.0f, Restart );	// restart after 1 sec.
	}
	
	public Vec2 Velocity 
	{
		get 
		{
			return _velocity;
		}
	}
	
	public void Restart(  Object sender,  Time.TimeoutEvent timeout ) 
	{
		_pausing = false;
		Console.WriteLine("Restart");
	}


}

