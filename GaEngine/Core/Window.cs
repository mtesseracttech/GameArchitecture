/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 2:27 PM
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using GaGame.GameObjects;

public class Window : Form
{
	private Game _game;
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
		_context.SetGraphics(e.Graphics);
		_game.Render(); 
	}
}
