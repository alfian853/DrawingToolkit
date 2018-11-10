using System.Diagnostics;
using System.Drawing;
using DrawingToolkit.DrawingStates;

namespace DrawingToolkit.DrawingObjects
{
    public class ConnectorLine : DobLine, IConnector
    {
        private IConnectable start;
        private IConnectable end;
        
        public ConnectorLine(int sX, int sY, int eX, int eY, Pen pen) : base(sX, sY, eX, eY, pen)
        {
        }

        public override bool isClickedAt(int x, int y, bool innerClick)
        {
            if (innerClick)
            {
                return false;
            }
            return base.isClickedAt(x, y, false);
        }

        private void updateConnectLine()
        {
            Point res = start.getOutlinePointFrom(eX, eY);
            sX = res.X;
            sY = res.Y;
            res = end.getOutlinePointFrom(sX, sY);
            eX = res.X;
            eY = res.Y;
        }

        public override void setMoveEnd(int x, int y)
        {
        }
        
        public void setConnectable(IConnectable start, IConnectable end)
        {
            this.start = start;
            this.end = end;
            this.start.attach(this);
            this.end.attach(this);
            this.updateConnectLine();
        }

        public void onObservedMove()
        {
            this.SetState(MovingState.GetInstance());
            this.updateConnectLine();
        }

        public void onObservedStatic()
        {
            this.SetState(StaticState.GetInstance());
        }
    }
}
