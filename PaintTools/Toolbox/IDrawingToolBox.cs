using DrawingToolkit.Canvas;

namespace DrawingToolkit.Toolbox
{
    public interface IDrawingToolBox : IToolbox
    {
        void OnDrawingToolClick(DrawingTool tool);
        ICanvas GetCanvas();
    }
}
