using System.Threading;
using System.Windows.Forms;
using ControllerApp.ControllerServices;
using ControllerApp.MouseServices;
using SharpDX.XInput;
namespace ControllerApp
{
    public partial class Form1 : Form
    {
        private void InitEngine()
        {
            Controller controller = new Controller(UserIndex.One);
            ControllerGamepad controllerGamepad = new ControllerGamepad(controller);
            ControllerState controllerState = new ControllerState();
            MouseMovement mouseMovement = new MouseMovement();
            while (controllerGamepad.IsConnected(controller))
            {
                controllerGamepad.Update(controllerState);
                Thread.Sleep(10);
                mouseMovement.MoveCursor(controllerState.rightThumb);
            }
        }
        public Form1()
        {
            InitializeComponent();
            ThreadStart runBackgroudEngine = new ThreadStart(InitEngine);
            Thread backgroundThread = new Thread(runBackgroudEngine);
            backgroundThread.Start();
            while (true)
            {
                if (!backgroundThread.IsAlive)
                {
                    backgroundThread = new Thread(runBackgroudEngine);
                    backgroundThread.Start();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
