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
using GaGame.GaEngine.Paddle;
using GaGame.GameObjects;

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

	private List<GameObject> _gameObjects;
	

	int ticksPerSecond = 60;
	private float timePerUpdate; //Time per update in seconds
	
	public Game()
	{
		_window = new Window( this );
	}	

	private void Build() 
	{
		//Ball setup
		var ballPhysics = new BallPhysicsComponent(new Vec2(0,0),new Vec2( 10, 10));
		var ballBehaviour = new BallBehaviourComponent(ballPhysics);
		var ballInput =  new BallInputComponent(ballBehaviour);
		ball = new Ball( "Ball", new Vec2(312,232) , "ball.png", ballPhysics, ballInput, ballBehaviour);
		
		//Left paddle setup
		var leftPaddlePhysics = new PaddlePhysicsManualComponent();
		var leftPaddleInput = new PaddleInputManualComponent(leftPaddlePhysics);
		leftPaddle = new Paddle( "Left", new Vec2(10, 208), "paddle.png", ball, leftPaddlePhysics, leftPaddleInput);

		//Right paddle setup
		var rightPaddlePhysics = new PaddlePhysicsAutoComponent();
		var rightPaddleInput = new PaddleInputAutoComponent(rightPaddlePhysics);
		rightPaddle = new Paddle( "Right", new Vec2(622, 208), "paddle.png", ball, rightPaddlePhysics, rightPaddleInput);
		
		//Left Score Text
		var leftText = new PaddleTextComponent("digits.png", "text", leftPaddle);
		leftScore = new Text( "LeftScore", new Vec2(320-20 - 66, 10), leftText);
		
		//Right Score Text
		var rightText = new PaddleTextComponent("digits.png","text", rightPaddle);
		rightScore = new Text( "RightScore", new Vec2(320+20, 10),rightText);

		//Booster 1 setup
		var booster1Physics = new BoosterPhysicsComponent();
		var booster1Behaviour = new BoosterBehaviourComponent(booster1Physics, ball);
		booster1 = new Booster( "Booster", new Vec2(304, 96), "booster.png", booster1Physics, booster1Behaviour);
		
		//Booster 2 setup
		var booster2Physics = new BoosterPhysicsComponent();
		var booster2Behaviour = new BoosterBehaviourComponent(booster2Physics, ball);
		booster2 = new Booster( "Booster", new Vec2(304, 384), "booster.png", booster2Physics, booster2Behaviour);
		
		SetGameSpeed(60); //Setting the default gamespeed
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
			Application.DoEvents();
			Time.Update();
			float current = Time.Now;
			float elapsed = current - previous;
			previous = current;
			lag += elapsed;
			
			ProcessInput();
			
			while (lag >= timePerUpdate)
			{
				Update();
				lag -= timePerUpdate;
			}
			
			TriggerRender(); //Cant pass anything into this currently without an ugly hack

			running = _window.Visible;
		}
	}

	public void ProcessInput()
	{
		ball.ProcessInput();
		leftPaddle.ProcessInput();
		rightPaddle.ProcessInput();
		booster1.ProcessInput();
		booster2.ProcessInput();
		leftScore.ProcessInput();
		rightScore.ProcessInput();
	}

	public void Update()
	{
		FrameCounter.Update();
		Time.Update();
		
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

