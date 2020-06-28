using System;
using System.Drawing;
using SharpDX.XInput;
namespace ControllerApp.ControllerServices
{
    class ControllerState
    {
        
        public Point leftThumb, rightThumb;
        public float leftTrigger, rightTrigger;
        public Gamepad gamepad;
        private int deadband = 2500;


        public ControllerState()
        {
            rightThumb = new Point(0, 0);
            leftThumb = new Point(0, 0);
            leftTrigger = 0;
            rightTrigger = 0;
        }

        public void Calculate()
        {
            leftThumb.X = (int)((Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100);
            leftThumb.Y = (int)((Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100);
            rightThumb.Y = (int)((Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100);
            rightThumb.X = (int)((Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100);
            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;
        }

    }
}
