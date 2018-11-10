using System.Drawing;

namespace DrawingToolkit.DrawingObjects
{
    public interface IConnectable
    {
        void attach(IConnector observer);
        Point getOutlinePointFrom(int sX, int sY);
    }
}
