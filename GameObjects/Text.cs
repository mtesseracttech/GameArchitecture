using System;
using System.Diagnostics;
using System.Drawing;
using GaGame.GaEngine;
using GaGame.GameObjects;

public class Text : GameObject
{
	private TextScoreComponent _graphics;
	
	public Text(string name, Vec2 position, TextScoreComponent graphics) : base(name, position)
	{
		_graphics = graphics;
	}

	public override void Render()
	{
		Debug.Assert(_graphics != null);
		_graphics.Update(this);
	}

	public TextScoreComponent Graphics
	{
		get { return _graphics; }
	}
}

