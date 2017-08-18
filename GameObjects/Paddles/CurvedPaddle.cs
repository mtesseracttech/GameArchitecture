/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 6:09 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

public class CurvedPaddle : Paddle
{
	public CurvedPaddle(string name, Vec2 position, string imageFile, Ball ball) : base(name, position, imageFile, ball){}

	public override void Update()
	{
		// input
		
		Velocity.Y = 0; // no move 
		if ( Input.Key.Pressed( Keys.Up ) ) Velocity.Y = -Speed;
		if ( Input.Key.Pressed( Keys.Down ) ) Velocity.Y = Speed;
		
		// move
		_position.Add( Velocity );
		
		// collisions & resolve
		if( Intersects( Ball.Position, Ball.Size ) ) 
		{
			if( Ball.Velocity.X > 0 ) 
			{
				Ball.Position.X = _position.X - Ball.Size.X;
			} else if( Ball.Velocity.X < 0 ) 
			{
				Ball.Position.X = _position.X + Size.X;
			}
			Ball.Velocity.X = -Ball.Velocity.X;
			Ball.Velocity.Y = ( Ball.Center.Y - Center.Y ) / 64 + ( (float)(Game.Random.NextDouble())-0.5f )/1.0f;
		}
		
		// collisions
		if( _position.Y < 0 ) _position.Y = 0;
		if( _position.Y > 416 ) _position.Y = 416;
	}


}