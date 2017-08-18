/*
 * User: Eelco
 * Date: 5/16/2017
 * Time: 9:05 AM
 */
using System;
using System.Diagnostics;
using System.Drawing;
using GaGame.GaEngine;
using GaGame.GameObjects;

public class Text : GameObject
{
	private PaddleTextComponent _graphics;
	
	public Text(string name, Vec2 position, string imageFile, Paddle paddle) : base(name, position)
	{
		_graphics = new PaddleTextComponent(imageFile, "text", paddle);
	}

	public void Render(Graphics graphics)
	{
		_graphics.Update(graphics, this);
	}
}

