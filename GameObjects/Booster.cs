/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 2:01 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using GaGame.GameObjects;


public class Booster : Sprite
{
	private bool _active = true;
	private Ball _ball;
	
	
	public Booster(string name, Vec2 position, string imageFile, Ball ball) : base(name, position, imageFile)
	{
		_ball = ball;
	}
	

	public void Update()
	{
		if( _active && Intersects( _ball.Position, _ball.Size ) ) 
		{
			_active = false;
			_ball.Boost();
			Time.Timeout( "Deboosting", 0.5f, DeBoost );
		}
	}
	
	// Event handlers

	private void DeBoost( Object sender,  Time.TimeoutEvent timeout )
	{
		_ball.DeBoost();
		_active = true;
	}	

	// Tools
	public bool Intersects( Vec2 otherPosition, Vec2 otherSize ) {
		return
		    _position.X < otherPosition.X+otherSize.X && _position.X + Size.X > otherPosition.X &&
		    _position.Y < otherPosition.Y+otherSize.Y && _position.Y + Size.Y > otherPosition.Y;
	}
	
	
	public void Reset() 
	{
		_position.X = 320-8;
		_position.Y = 240-8;
	}
}

