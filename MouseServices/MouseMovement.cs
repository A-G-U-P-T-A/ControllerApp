using System.Drawing;
using System.Windows.Forms;

namespace ControllerApp.MouseServices
{
    class MouseMovement
    {
        public Cursor Cursor { get; private set; }
        
        public void MoveCursor(Point rightThumb)
        {
            int X=0, Y=0;
            if (rightThumb.X == 0 && rightThumb.Y == 0)
                return;
            if (rightThumb.X > 0)
                Y = 10;
            if (rightThumb.X < 0)
                Y = -10;
            if (rightThumb.Y > 0)
                X = -10;
            if (rightThumb.Y < 0)
                X = +10;
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - X, Cursor.Position.Y - Y);
        }
    }
}
