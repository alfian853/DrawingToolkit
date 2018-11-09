using DrawingToolkit.DrawingObjects;
using System.Drawing;

namespace DrawingToolkit.DrawingStates
{
    public abstract class DrawingState
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public abstract void Draw(DrawingObject obj);

        public virtual void Deselect(DrawingObject obj)
        {
            //default implementation, no state transition
        }

        public virtual void Select(DrawingObject obj)
        {
            //default implementation, no state transition
        }
    }
}
