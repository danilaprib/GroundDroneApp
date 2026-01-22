using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GroundDroneApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort SERIAL_PORT;
        public MainWindow()
        {
            InitializeComponent();

            SERIAL_PORT = new SerialPort();
            SERIAL_PORT.PortName = "COM3";
            SERIAL_PORT.BaudRate = 9600;
            SERIAL_PORT.DataBits = 8;
            SERIAL_PORT.Parity = Parity.None;
            SERIAL_PORT.StopBits = StopBits.One;


            // L 76  R 82    horizontal
            // l 108 r 114   vertical
            try
            {
                SERIAL_PORT.Open();
                ComPortStatus.Text = "port opened";
            }
            catch(System.IO.FileNotFoundException ex)
            {
                ComPortStatus.Text = "port failed to open";
            }

        }
        private void RotateCamLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamHoriz.Text);
            degree--;
            CamHoriz.Text = degree.ToString();


            byte[] bytes = Encoding.UTF8.GetBytes("L");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);

            //SERIAL_PORT.Write()
            // l 108
        }

        private void RotateCamRightBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamHoriz.Text);
            degree++;
            CamHoriz.Text = degree.ToString();


            byte[] bytes = Encoding.UTF8.GetBytes("R");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void RotateCamUpBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamVert.Text);
            degree++;
            CamVert.Text = degree.ToString();


            byte[] bytes = Encoding.UTF8.GetBytes("r");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void RotateCamDownBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamVert.Text);
            degree--;
            CamVert.Text = degree.ToString();


            // l 108 down
            byte[] bytes = Encoding.UTF8.GetBytes("l");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void MoveLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            //MoveLeftBtn.Background = new SolidColorBrush(Colors.Green);



            //if (checkColor)
            //{
            //    MoveForwBtn.Background = new SolidColorBrush(Colors.White);
            //    checkColor = false;
            //    return;
            //}
            //if (Keyboard.IsKeyDown(Key.A))
            //    MoveLeftBtn.Background = new SolidColorBrush(Colors.Green);

            //_timer.Enabled = true;
            ////else
            ////    MoveLeftBtn.Background = new SolidColorBrush(Colors.White);


            ////if (Keyboard.IsKeyToggled(Key.A))
            ////{
            ////    MoveLeftBtn.Background = Brushes.Red;
            ////}
            ////else
            ////{
            ////    btnIsToggle.Background = Brushes.AliceBlue;
            ////}

            ////MoveForwBtn.Focus();
            //Debug.WriteLine("LEFT: " + MoveLeftBtn.IsPressed);

            //_timer.Enabled = true;
        }

        private void MoveRightBtn_Click(object sender, RoutedEventArgs e)
        {
            
            //if (checkColor)
            //{
            //    MoveForwBtn.Background = new SolidColorBrush(Colors.White);
            //    checkColor = false;
            //    return;
            //}

            //if (Keyboard.IsKeyDown(Key.D))
            //    MoveRightBtn.Background = new SolidColorBrush(Colors.Green);
            //_timer.Enabled = true;
            ////else
            ////    MoveRightBtn.Background = new SolidColorBrush(Colors.White);
            ////MoveForwBtn.Focus();
            //Debug.WriteLine("RIGHT: " + MoveRightBtn.IsPressed);
            ////MoveRightBtn.Background = new SolidColorBrush(Colors.Green);
            //_timer.Enabled = true;
        }
        
        private void MoveForwBtn_Click(object sender, RoutedEventArgs e)
        {

            //if (checkColor)
            //{
            //    MoveForwBtn.Background = new SolidColorBrush(Colors.White); 
            //    checkColor = false;
            //    return;
            //}
            ////MoveForwBtn.Is

            //if (Keyboard.IsKeyDown(Key.W))
            //    MoveForwBtn.Background = new SolidColorBrush(Colors.Green);

            //_timer.Enabled = true;
            ////else
            ////    MoveForwBtn.Background = new SolidColorBrush(Colors.White);

            ////MoveForwBtn.Focus();

            //Debug.WriteLine("FORW: " + MoveForwBtn.IsPressed);
            ////MoveForwBtn.Background = new SolidColorBrush(Colors.Green);

            //_timer.Enabled = true;
        }

        private void MoveBackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KillAppCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void KillAppCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            KillBtn_Click(this, null);
        }

        private void KillBtn_Click(object sender, RoutedEventArgs e)
        {
            // S 83 s 115

            // K 75 kill
            byte[] bytes = Encoding.UTF8.GetBytes("K");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);

            SERIAL_PORT.Close();
            SERIAL_PORT.Dispose();

            Debug.WriteLine("is port null: " + SERIAL_PORT == null);

            ComPortStatus.Text = $"is port null = {SERIAL_PORT == null}";

            KillBtn.Background = new SolidColorBrush(Colors.Red);
        }

        private void HandbrakeOffBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("K");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void RotateCamLeftBtn_KeyUp(object sender, KeyEventArgs e)
        {
            // S 83


            byte[] bytes = Encoding.UTF8.GetBytes("S");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void RotateCamRightBtn_KeyUp(object sender, KeyEventArgs e)
        {
            // S 83


            byte[] bytes = Encoding.UTF8.GetBytes("S");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }



        private void RotateCamUpBtn_KeyUp(object sender, KeyEventArgs e)
        {

            // s 115


            byte[] bytes = Encoding.UTF8.GetBytes("s");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        private void RotateCamDownBtn_KeyUp(object sender, KeyEventArgs e)
        {

            // s 115


            byte[] bytes = Encoding.UTF8.GetBytes("s");
            if (ComPortStatus.Text != "port failed to open")
                SERIAL_PORT.Write(bytes, 0, bytes.Length);
        }

        //private void CamHoriz_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{

        //}
    }


    // Camera commands
    public partial class MainWindow : Window
    {
        // UP
        private void PressCamUpCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PressCamUpCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RotateCamUpBtn_Click(this, null);
        }


        // DOWN
        private void PressCamDownCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PressCamDownCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RotateCamDownBtn_Click(this, null);
        }


        // LEFT
        private void PressCamLeftCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PressCamLeftCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RotateCamLeftBtn_Click(this, null);
        }


        // RIGHT
        private void PressCamRightCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PressCamRightCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RotateCamRightBtn_Click(this, null);
        }

    }



    // Tracks commands
    public partial class MainWindow : Window
    {
        // MOVE FORW
        private void MoveForwCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            //if (!Keyboard.IsKeyDown(Key.W))
            //{
            //    MoveForwBtn.Background = new SolidColorBrush(Colors.White);
            //}
            e.CanExecute = true;
            //e.CanExecute = !MoveBackBtn.IsPressed && !MoveLeftBtn.IsPressed && !MoveRightBtn.IsPressed;
        }

        private void MoveForwCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //Debug.WriteLine(e.RoutedEvent);
            //MoveForwBtn.RaiseEvent(e.)
            MoveForwBtn_Click(this, null);
        }

        // MOVE BACK
        private void MoveBackCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MoveBackCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            MoveBackBtn_Click(this, null);
        }

        // MOVE LEFT
        private void MoveLeftCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MoveLeftCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            MoveLeftBtn_Click(this, null);
        }

        // MOVE RIGHT
        private void MoveRightCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MoveRightCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            MoveRightBtn_Click(this, null);
        }


    }
}