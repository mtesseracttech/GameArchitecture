/*
 * User: Eelco
 * Date: 5/13/2017
 * Time: 4:36 PM
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using KeyEventHandler = System.Windows.Forms.KeyEventHandler;


public class KeyInput : IInput
{
	public static void Register(Form form)
	{
		InputLocator.ProvideInput(new KeyInput(form));
	}
	
	private Dictionary<Keys, float> keys = new Dictionary<Keys, float>();
	
	private KeyInput(Form form)
	{
		form.KeyDown += new KeyEventHandler( Down );
		form.KeyUp += new KeyEventHandler( Up );
	}
	
	private void Down( Object sender, KeyEventArgs e ) 
	{
		Keys key = e.KeyCode;
		float time = 0;
		keys.TryGetValue( key, out time );
		if( time == 0 ) 
		{ // non exists or upped
			keys[ key ] = Time.Real;
		}
	}
	
	private void Up( Object sender, KeyEventArgs e ) 
	{
		keys[ e.KeyCode ] = 0;
	}
	
	public bool Enter(Keys key)
	{
		float time = 0;
		if( keys.TryGetValue( key, out time ) ) 
		{
			return time > Time.Now - Time.Step;
		}
		return false;
	}

	public bool Pressed(Keys key)
	{
		float time = 0;
		if( keys.TryGetValue( key, out time ) ) {
			return time > 0;
		}
		return false;
	}
}

