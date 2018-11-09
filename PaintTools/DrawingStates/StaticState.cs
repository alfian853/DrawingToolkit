using DrawingToolkit.DrawingObjects;

namespace DrawingToolkit.DrawingStates
{
    public class StaticState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new StaticState();
            }
            return instance;
        }

        public override void Draw(DrawingObject obj)
        {
            obj.Draw();
        }
    }
}
