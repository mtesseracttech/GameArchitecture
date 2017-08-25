/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 2:01 PM
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GaGame.GameObjects;


public class Booster : Sprite
{
	private BoosterBehaviourComponent _behaviour;
	private BoosterPhysicsComponent _physics;//has no real use at this point, except to store an intersect function
	
	public Booster(string name, Vec2 position, string imageFile, BoosterPhysicsComponent physics, BoosterBehaviourComponent behaviour) : base(name, position, imageFile)
	{
		_physics = physics;
		_behaviour = behaviour; 
	}
	
	public override void Update()
	{   
		Debug.Assert(_behaviour != null);
		_behaviour.Update(this);
		_physics.Update(this);
	}

	public BoosterPhysicsComponent Physics
	{
		get { return _physics; }
	}
	
	public BoosterBehaviourComponent Behaviour
	{
		get { return _behaviour; }
	}
}

