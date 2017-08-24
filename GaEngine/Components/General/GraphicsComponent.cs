namespace GaGame.GaEngine
{
    public class GraphicsComponent
    {
        protected IGraphics _graphicsService;

        public GraphicsComponent()
        {
            _graphicsService = GraphicsLocator.GetGraphics();
        }
    }
}