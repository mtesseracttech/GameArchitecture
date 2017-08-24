/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 2:27 PM
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using GaGame.GameObjects;

public class Window : Form
{
	private Game _game;
	private Graphics _graphics;
	private RenderContext _context;
	
	public Window( Game aGame )
	{
		_game = aGame;
		BackColor = System.Drawing.Color.Black;
		SuspendLayout();
		Name = "GaGame";
		ClientSize = new System.Drawing.Size( 640, 480 );
		DoubleBuffered = true; // avoid flickering
		ResumeLayout();	
		Show();
		KeyInput.Register(this);
		_context = new RenderContext();
		_context.Register();
	}
	
	protected override void OnPaint( PaintEventArgs e )  // adapter for caching repaints for updates
	{
		//_graphics = e.Graphics;
		_context.SetGraphics(e.Graphics);
		_game.Render(); 
	}
	/*
	public void DrawSprite(Image image, Vec2 position)
	{
		Debug.Assert(_graphics != null);
		Debug.Assert(image != null);
		_graphics.DrawImage(image, position.X, position.Y);
	}

	public void DrawSpriteSelection(Image image, Vec2 position, Vec2 rectCorner, Vec2 rectSize)
	{
		Debug.Assert(_graphics != null);
		Debug.Assert(image != null);
		Rectangle rect = new Rectangle((int)rectCorner.X, (int)rectCorner.Y, (int)rectSize.X, (int)rectSize.Y);
		_graphics.DrawImage( image, position.X, position.Y, rect, GraphicsUnit.Pixel );
	}
	*/
}
