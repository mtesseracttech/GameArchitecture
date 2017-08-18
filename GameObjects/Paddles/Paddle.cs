/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 2:01 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using GaGame.GameObjects;


public class Paddle : Sprite
{
	protected Vec2 Velocity = null;
	protected Ball Ball = null;
	
	protected uint score;
	
	public const float Speed = 5.0f;
	
	
	public Paddle(string name, Vec2 position, string imageFile, Ball ball) : base(name, position, imageFile)
	{
		Velocity = new Vec2( 0, 0 );
		Ball = ball;
		score = 0;		
	}
	
	public virtual void Update()
	{
		// input
		Velocity.Y = 0; // no move 
		if ( Input.Key.Pressed( Keys.Up ) ) Velocity.Y = -Speed;
		if ( Input.Key.Pressed( Keys.Down ) ) Velocity.Y = Speed;
		
		// move
		_position.Add( Velocity );
		
		// collisions & resolve
		if( Intersects( Ball.Position, Ball.Size ) ) {
			if( Ball.Velocity.X > 0 ) {
				Ball.Position.X = _position.X - Ball.Size.X;
			} else if( Ball.Velocity.X < 0 ) {
				Ball.Position.X = _position.X + Size.X;
			}
			Ball.Velocity.X = -Ball.Velocity.X;
		}
		
		// collisions
		if( _position.Y < 0 ) _position.Y = 0;
		if( _position.Y > 416 ) _position.Y = 416;
	}
	
	public void IncScore() 
	{
		score++;
	}

	public bool Intersects( Vec2 otherPosition, Vec2 otherSize ) {
		return
		    _position.X < otherPosition.X+otherSize.X && _position.X + Size.X > otherPosition.X &&
		    _position.Y < otherPosition.Y+otherSize.Y && _position.Y + Size.Y > otherPosition.Y;
	}
	
	public Vec2 Center 
	{
		get {
			return _position + 0.5f * Size;
		}
	}	
	
	public Vec2 Size 
	{
		get { 
			return new Vec2( _image.Width, _image.Height ); 
		}
	}	

	public uint Score 
	{
		get { 
			return score; 
		}
	}	
	

}


