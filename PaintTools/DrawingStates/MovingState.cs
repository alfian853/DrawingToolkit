using DrawingToolkit.DrawingObjects;

namespace DrawingToolkit.DrawingStates
{
    public class MovingState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new MovingState();
            }
            return instance;
        }

        public override void Draw(DrawingObject obj)
        {
            obj.DrawMoving();
        }
    }
}
