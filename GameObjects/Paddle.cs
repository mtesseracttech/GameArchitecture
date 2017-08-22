using System.Windows.Forms;
using GaGame.GaEngine;
using GaGame.GameObjects;


public class Paddle : Sprite
{
	private Ball _ball;
	private uint _score;
	private PaddleInputComponent _input;
	private PaddlePhysicsComponent _physics;
	
	public Paddle(string name, Vec2 position, string imageFile, Ball ball, PaddlePhysicsComponent physics, PaddleInputComponent input) : base(name, position, imageFile)
	{
		_ball = ball;
		_score = 0;
		_input = input;
		_physics = physics;
	}

	public override void ProcessInput()
	{
		_input.Update(this, _ball);
	}
	
	public override void Update()
	{
		_physics.Update(this, _ball);
	}

	public void IncScore() 
	{
		_score++;
	}

	public uint Score 
	{
		get {return _score; }
	}	
	

}


