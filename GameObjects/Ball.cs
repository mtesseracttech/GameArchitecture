using System.Diagnostics;
using GaGame.GameObjects;


public class Ball : Sprite
{
	private readonly BallBehaviourComponent _behaviour;
	private readonly BallInputComponent _input;
	private readonly BallPhysicsComponent _physics;
	
	
	public Ball(string name, Vec2 position, string imageFile, BallPhysicsComponent physics, BallInputComponent input, BallBehaviourComponent behaviour) : base(name, position, imageFile)
	{
		_physics = physics;
		_input = input;
		_behaviour = behaviour;
		_behaviour.Reset(this);
	}

	public override void ProcessInput()
	{
		_input.Update();
	}

	public override void Update()
	{
		Debug.Assert(_behaviour != null);
		Debug.Assert(_physics != null);
		_behaviour.Update(this);
		_physics.Update(this);
	}

	public void Restart(object sender, Time.TimeoutEvent e)
	{
		_behaviour.Restart(sender, e);
	}

	public void Reset()
	{
		_behaviour.Reset(this);
	}

	public void Boost()
	{
		_physics.Boost();
	}

	public void DeBoost()
	{
		_physics.DeBoost();
	}

	public Vec2 Velocity
	{
		get{ return _physics.Velocity; }
	}
}

