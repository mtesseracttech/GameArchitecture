
public abstract class InputComponent
{
    protected IInput _inputService;
    
    public InputComponent()
    {
        _inputService = InputLocator.GetInput();
    }
}