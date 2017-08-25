/*
 * Saxion, Game Architecture
 * User: Eelco Jannink
 * Date: 19-5-2016
 * Time: 16:55
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GaGame.GameObjects;

public class Game
{
	[STAThread] // needed to use wpf Keyboard.isKeyPressed when single threaded !
	public static void Main() 
	{
		Logger.Log( "Starting Game, close with Escape");
		Game game;
		game = new Game();
		game.Build();
		game.Run();
		game.Close();
		Logger.Log( "Closed window");

	}

	private static Random random = new Random( 0 ); // seed for repeatability.
	
	private Window _window;
	
	private Text _leftScore;
	private Text _rightScore;
	private Ball _ball;
	private Paddle _leftPaddle;
	private Paddle _rightPaddle;
	private Booster _booster1;
	private Booster _booster2;

	private List<GameObject> _gameObjects;
	private PhysicsHandler _physicsHandler;

	int _ticksPerSecond = 60;
	private float _timePerUpdate; //Time per update in seconds
	
	public Game()
	{
		InputLocator.Initialize();
		PhysicsLocator.Initialize();
		GraphicsLocator.Initialize();
		_window = new Window( this );
		Vec2 fieldSize = new Vec2(_window.ClientSize.Width, _window.ClientSize.Height);
		_physicsHandler = new PhysicsHandler(fieldSize);
		PhysicsLocator.ProvidePhysics(_physicsHandler);
	}	

	private void Build() 
	{
		//Ball setup
		var ballPhysics = new BallPhysicsComponent(new Vec2(0,0),new Vec2( 10, 10), _window.ClientSize);
		var ballBehaviour = new BallBehaviourComponent(ballPhysics);
		var ballInput =  new BallInputComponent(ballBehaviour);
		_ball = new Ball("Ball", new Vec2(312,232) , "ball.png", ballPhysics, ballInput, ballBehaviour);

		
		//Left paddle setup
		//var leftPaddlePhysics = new PaddlePhysicsManualComponent(); //Uncomment for manual mode
		var leftPaddlePhysics = new PaddlePhysicsAutoComponent();
		var leftPaddleInput = new PaddleInputManualComponent(leftPaddlePhysics);
		//var leftPaddleInput = new PaddleInputAutoComponent(leftPaddlePhysics);
		_leftPaddle = new Paddle("Left", new Vec2(10, 208), "paddle.png", _ball, leftPaddlePhysics, leftPaddleInput);

		//Right paddle setup
		var rightPaddlePhysics = new PaddlePhysicsAutoComponent();
		var rightPaddleInput = new PaddleInputAutoComponent(rightPaddlePhysics);
		_rightPaddle = new Paddle("Right", new Vec2(622, 208), "paddle.png", _ball, rightPaddlePhysics, rightPaddleInput);
		
		//Left Score Text
		var leftText = new TextDrawPaddleComponent("digits.png", "0", _leftPaddle);
		_leftScore = new Text("LeftScore", new Vec2(320-20 - 66, 10), leftText);
		
		//Right Score Text
		var rightText = new TextDrawPaddleComponent("digits.png","0", _rightPaddle);
		_rightScore = new Text("RightScore", new Vec2(320+20, 10),rightText);

		//Booster 1 setup
		var booster1Behaviour = new BoosterBehaviourComponent(_ball);
		var booster1Physics = new BoosterPhysicsComponent(booster1Behaviour, _ball);
		_booster1 = new Booster("Booster", new Vec2(304, 96), "booster.png", booster1Physics, booster1Behaviour);
		
		//Booster 2 setup
		var booster2Behaviour = new BoosterBehaviourComponent(_ball);
		var booster2Physics = new BoosterPhysicsComponent(booster2Behaviour,_ball);
		_booster2 = new Booster("Booster", new Vec2(304, 384), "booster.png", booster2Physics, booster2Behaviour);

		_gameObjects = new List<GameObject> //To make the update loops a bit cleaner
		{
			_ball,
			_leftPaddle,
			_rightPaddle,
			_leftScore,
			_rightScore,
			_booster1,
			_booster2
		};
		
		_physicsHandler.RegisterPhysicsComponent(_ball, ballPhysics);
		_physicsHandler.RegisterPhysicsComponent(_leftPaddle,leftPaddlePhysics);
		_physicsHandler.RegisterPhysicsComponent(_rightPaddle, rightPaddlePhysics);
		_physicsHandler.RegisterPhysicsComponent(_booster1, booster1Physics);
		_physicsHandler.RegisterPhysicsComponent(_booster2, booster2Physics);
		
		
		SetGameSpeed(60); //Setting the default gamespeed
	}


	public void SetGameSpeed(int tps)
	{
		if (tps > 0)
		{
			_ticksPerSecond = tps;
			_timePerUpdate = 1.0f / _ticksPerSecond;
		}
	}
	
	public void Run() {
		Time.Timeout( "Reset", 1.0f, _ball.Restart);
		
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
			
			while (lag >= _timePerUpdate)
			{
				Update();
				lag -= _timePerUpdate;
			}
			
			TriggerRender(); //Cant pass anything into this currently without an ugly hack

			running = _window.Visible;
		}
	}

	public void ProcessInput()
	{
		foreach (var gameObject in _gameObjects)
		{
			gameObject.ProcessInput();
		}
	}

	public void Update()
	{
		FrameCounter.Update();
		Time.Update();
		
		foreach (var gameObject in _gameObjects)
		{
			gameObject.Update();
		}
		
		if( _ball.Position.X < 0 ) 
		{
			_rightPaddle.IncScore();
			_ball.Reset();
		}		
		if( _ball.Position.X > 640-16 ) 
		{
			_leftPaddle.IncScore();
			_ball.Reset();
		}
	}

	private void TriggerRender()
	{
		_window.Refresh();
	}

	public void Render()
	{
		foreach (var gameObject in _gameObjects)
		{
			gameObject.Render();
		}
	}
	
	public void Close()
	{
		_window.Close();
	}
	
	public static Random Random {
		get 
		{
			return random;
		}
	}

}

