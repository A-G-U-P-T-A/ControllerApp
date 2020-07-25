using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ControllerApp.ControllerServices;
using ControllerApp.KeyboardServices;
using ControllerApp.MouseServices;
using SharpDX.XInput;

namespace ControllerApp
{
    public partial class Form1 : Form
    {
        private static void InitEngine()
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
            }//data structure

        }

        static ThreadStart runBackgroudEngine = new ThreadStart(InitEngine);
        Thread backgroundThread;


        public Form1()
        {
            
            InitializeComponent();
            
        }


        private void start_HellControls(object sender, System.EventArgs e)
        {
            if (backgroundThread == null)
            {
                backgroundThread = new Thread(runBackgroudEngine);
                backgroundThread.Start();
            }
        }
        private void stop_HellControls(object sender, System.EventArgs e)
        {
            if(backgroundThread!=null)
                backgroundThread.Abort();
            backgroundThread = null;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
