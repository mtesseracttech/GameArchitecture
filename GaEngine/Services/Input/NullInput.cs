using System.Windows.Forms;

public class NullInput : IInput
{
    public bool Enter(Keys key)
    {
        return false;
    }

    public bool Pressed(Keys key)
    {
        return false;
    }
}