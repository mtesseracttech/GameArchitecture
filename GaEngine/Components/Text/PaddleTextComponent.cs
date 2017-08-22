using System.Diagnostics;
using System.Drawing;

public class PaddleTextComponent
{
    private string _text;
    private Image _image;
    private Paddle _paddle;
    
    public PaddleTextComponent(string imageFile, string text, Paddle paddle)
    {
        _image = Image.FromFile( imageFile );
        _text = text;
        _paddle = paddle;
        Debug.Assert(_paddle != null);
    }
    
    public void Update(Graphics graphics, Text text)
    {
        Debug.Assert(graphics != null);
        Debug.Assert(text != null);
        
        int digits = 2;
        string score = "000"+_paddle.Score;
        for( int d=0; d<digits; d++ ) 
        { // 3 digits left to right
            int digit = score[ score.Length-digits + d ] - 48; // '0' => 0 etc
            Rectangle rect = new Rectangle( digit * _image.Width/10, 0, _image.Width/10, _image.Height );
            graphics.DrawImage( _image, text.Position.X + d*_image.Width/10, text.Position.Y, rect, GraphicsUnit.Pixel );
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