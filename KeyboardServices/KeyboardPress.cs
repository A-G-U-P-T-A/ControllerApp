using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace ControllerApp.KeyboardServices
{
    class KeyboardPress
    {
        public void Test()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
        }
    }
}
