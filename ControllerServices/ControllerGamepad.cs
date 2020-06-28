using System;
using SharpDX.XInput;

namespace ControllerApp.ControllerServices
{
    class ControllerGamepad
    {
        Controller controller;
        
        public ControllerGamepad(Controller controller)
        {
            this.controller = controller;
        }


        public Boolean IsConnected(Controller controller)
        {
            if (controller.IsConnected)
                return true;
            return false;
        }    

        public void Update(ControllerState controllerState)
        {
            try
            {
                controllerState.gamepad = controller.GetState().Gamepad;
            }
            catch (SharpDX.SharpDXException e)
            {
                Console.WriteLine("Console Not Connected " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            controllerState.Calculate();
            return;
        }
    }
}
