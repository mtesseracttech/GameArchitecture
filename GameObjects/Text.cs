using System;
using System.Diagnostics;
using System.Drawing;
using GaGame.GaEngine;
using GaGame.GameObjects;

public class Text : GameObject
{
	private PaddleTextComponent _graphics;
	
	public Text(string name, Vec2 position, PaddleTextComponent graphics) : base(name, position)
	{
		_graphics = graphics;
	}

	public override void Render(Graphics graphics)
	{
		_graphics.Update(graphics, this);
	}
}

