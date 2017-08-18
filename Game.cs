/*
 * Saxion, Game Architecture
 * User: Eelco Jannink
 * Date: 19-5-2016
 * Time: 16:55
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

public class Game
{
	[STAThread] // needed to use wpf Keyboard.isKeyPressed when single threaded !
	public static void Main() 
	{
		Console.WriteLine( "Starting Game, close with Escape");
		Game game;
		game = new Game();
		game.Build();
		game.Run();
		game.Close();
		Console.WriteLine( "Closed window");

	}

	private static Random random = new Random( 0 ); // seed for repeatability.
	
	private Window _window;
	
	private Text leftScore;
	private Text rightScore;
	
	private Ball ball;
	private Paddle leftPaddle;
	private Paddle rightPaddle;
	private Booster booster1;
	private Booster booster2;

	int ticksPerSecond = 60;
	private float timePerUpdate; //Time per update in seconds
	
	public Game()
	{
		_window = new Window( this );
	}	

	private void Build() 
	{
		ball = new Ball( "Ball", new Vec2(312,232) , "ball.png");
		leftPaddle = new AutoPaddle( "Left", new Vec2(10, 208), "paddle.png", ball );
		rightPaddle = new AutoPaddle( "Right", new Vec2(622, 208), "paddle.png", ball );
		
		leftScore = new Text( "LeftScore", new Vec2(320-20 - 66, 10), "digits.png", leftPaddle );
		rightScore = new Text( "RightScore", new Vec2(320+20, 10), "digits.png", rightPaddle );

		booster1 = new Booster( "Booster", new Vec2(304, 96), "booster.png", ball );
		booster2 = new Booster( "Booster", new Vec2(304, 384), "booster.png", ball );
		
		SetGameSpeed(60);
	}


	public void SetGameSpeed(int tps)
	{
		if (tps > 0)
		{
			ticksPerSecond = tps;
			timePerUpdate = 1.0f / ticksPerSecond;
		}
	}
	
	public void Run() {
		Time.Timeout( "Reset", 1.0f, ball.Restart);
		
		float previous = Time.Now;
		float lag = 0.0f;
		
		bool running = true;
		while (running)
		{
			Time.Update();
			float current = Time.Now;
			float elapsed = current - previous;
			previous = current;
			lag += elapsed;
			
			ProcessInput();
			
			//float oldLag = lag;
			//int i = 0;
			while (lag >= timePerUpdate)
			{
				Update();
				lag -= timePerUpdate;
				//i++;
			}
			
			//Console.WriteLine("Prev Lag: " + oldLag + " | Leftover Lag: " + lag + " | Updates: " + i);
			
			TriggerRender();

			running = _window.Visible;
		}
	}

	public void ProcessInput()
	{
		Application.DoEvents();
	}

	public void Update()
	{
		FrameCounter.Update();
		
		ball.Update();
		leftPaddle.Update();
		rightPaddle.Update();
		booster1.Update();
		booster2.Update();
		leftScore.Update();
		rightScore.Update();
		
		if( ball.Position.X < 0 ) 
		{
			rightPaddle.IncScore();
			ball.Reset();
		}		
		if( ball.Position.X > 640-16 ) 
		{
			leftPaddle.IncScore();
			ball.Reset();
		}
	}

	private void TriggerRender()
	{
		_window.Refresh();
	}

	public void Render(Graphics graphics)
	{
		ball.Render(graphics);
		leftPaddle.Render(graphics);
		rightPaddle.Render(graphics);
		booster1.Render(graphics);
		booster2.Render(graphics);
		leftScore.Render(graphics);
		rightScore.Render(graphics);
	}
	
	public void Close() {
		_window.Close();
	}
	
	public static Random Random {
		get 
		{
			return random;
		}
	}

}

