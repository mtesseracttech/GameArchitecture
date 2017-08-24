using System.Diagnostics;
using System.Drawing;
using GaGame.GaEngine;

public class TextDrawPaddleComponent : GraphicsComponent
{
    private string _text;
    private Image _image;
    private Paddle _paddle;
    
    public TextDrawPaddleComponent(string imageFile, string text, Paddle paddle)
    {
        _image = Image.FromFile( imageFile );
        _text = text;
        _paddle = paddle;
        _graphicsService = GraphicsLocator.GetGraphics();
        Debug.Assert(_paddle != null);
    }
    
    public void Update(Text text)
    {
        Debug.Assert(text != null);
        
        int digits = 2;
        string score = "000"+_paddle.Score;
        for( int d=0; d<digits; d++ ) 
        { // 3 digits left to right
            int digit = score[ score.Length-digits + d ] - 48; // '0' => 0 etc
            Vec2 position = new Vec2(text.Position.X + d * _image.Width / 10, text.Position.Y);
            Vec2 rectCorner = new Vec2(digit * _image.Width/10, 0);
            Vec2 rectSize = new Vec2(_image.Width/10, _image.Height);
            _graphicsService.DrawSpriteSelection(_image, position, rectCorner, rectSize);
        }
    }
    
    public string Value 
    {
        get
        {
            return _text;
        }
        set 
        {
            _text = value;
        }
    }
}