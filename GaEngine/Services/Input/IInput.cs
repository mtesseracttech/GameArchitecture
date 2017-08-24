using System.Windows.Forms;

public interface IInput
{
    bool Enter(Keys key);
    bool Pressed(Keys key);
}