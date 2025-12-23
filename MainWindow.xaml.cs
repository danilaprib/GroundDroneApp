using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using System.IO.Ports;
using System.Windows.Media;

namespace GroundDroneApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        

        private string _currentTime;

        bool isHandbrakeOn = false;

        string _currentGear = "q";
        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;

                // Notify listeners (WPF) that the property changed
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(CurrentTime))
                );
            }
        }

        public string CurrentDate { get; set; }
        public string CurrentDayOfWeek { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        Gears _gear;

        //string[] ports = SerialPort.GetPortNames();
        SerialPort _serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One); // Parity.None, 8, StopBits.One

        public MainWindow()
        {


            InitializeComponent();


            Dispatcher.ShutdownStarted += DisposeOfResources;
            _gear = Gears.First;

            // Tell WPF to look at this object for bindings
            DataContext = this;


            var date = DateTime.Now;
            CurrentDayOfWeek = date.DayOfWeek.ToString();
            CurrentDate = date.Date.ToString("yyyy MMM dd");


            // Create a timer that runs on the UI thread
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            // This code runs once per second
            timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            };

            timer.Start();

            //if (_serialPort != null)
            //{
            //    _serialPort.Open();
            //}



            try
            {
                _serialPort.Open();

                ComPortStatus.Text = "ON";
                ComPortStatus.Foreground = new SolidColorBrush(Colors.Green);
                ComPortStatusLED.Fill = new SolidColorBrush(Colors.Green);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                ComPortStatus.Text = "OFF";
                ComPortStatus.Foreground = new SolidColorBrush(Colors.Red);
                ComPortStatusLED.Fill = new SolidColorBrush(Colors.Red);
            }

            //Task.Run(StatusCheck);
        }

        //public void StatusCheck()
        //{
        //    while (true)
        //    {

        //    }
        //}


        public void DisposeOfResources(object? sender, EventArgs e)
        {
            this._serialPort.Dispose();
        }

        //public override void Shutdown()
        //{
        //    this._serialPort.Dispose();
            
        //}

        private void HandbrakeOffBtn_Click(object sender, RoutedEventArgs e)
        {
            MoveUpBtn.IsEnabled = true;
            MoveDownBtn.IsEnabled = true;
            MoveLeftBtn.IsEnabled = true;
            MoveRightBtn.IsEnabled = true;

            HandbrakeOnBtn.IsEnabled = true;
            HandbrakeOffBtn.IsEnabled = false;


            Debug.WriteLine("handbrake OFF");
            isHandbrakeOn = false;
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {
                _serialPort.WriteLine(_currentGear);
            }
        }

        private void HandbrakeOnBtn_Click(object sender, RoutedEventArgs e)
        {

            MoveUpBtn.IsEnabled = false;
            MoveDownBtn.IsEnabled = false;
            MoveLeftBtn.IsEnabled = false;
            MoveRightBtn.IsEnabled = false;

            HandbrakeOnBtn.IsEnabled = false;
            HandbrakeOffBtn.IsEnabled = true;

            Debug.WriteLine("handbrake ON");
            isHandbrakeOn = true;
            if (_serialPort.IsOpen && isHandbrakeOn)
            {
                _serialPort.WriteLine("s");
            }
        }

        private void GearOneBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.First;

            GearOneBtn.IsEnabled = false;

            GearTwoBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);

            _currentGear = "q";
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {
                
                _serialPort.WriteLine(_currentGear);
            }
        }

        private void GearTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Second;

            GearTwoBtn.IsEnabled = false;

            GearOneBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);
            _currentGear = "w";
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {

                _serialPort.WriteLine(_currentGear);
            }
        }

        private void GearThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Third;

            GearThreeBtn.IsEnabled = false;


            GearOneBtn.IsEnabled = true;
            GearTwoBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: "  + (int)_gear);

            _currentGear = "e";
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {

                _serialPort.WriteLine(_currentGear);
            }
        }

        private void GearFourBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Fourth;

            GearFourBtn.IsEnabled = false;


            GearOneBtn.IsEnabled = true;
            GearTwoBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);
            _currentGear = "r";
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {

                _serialPort.WriteLine(_currentGear);
            }
        }

        private void MoveUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_serialPort.IsOpen && !isHandbrakeOn)
            {
                _serialPort.WriteLine("a");
            }
        }

        private void MoveDownBtn_Click(object sender, RoutedEventArgs e)
        {

            if (_serialPort.IsOpen && !isHandbrakeOn)
            {
                _serialPort.WriteLine("d");
            }
        }

        //private void Exit_App(object sender, RoutedEventArgs e)
        //{
        //    this._serialPort.Dispose();
        //    Application.Exit();
        //    Application.Shutdown();
        //}
    }
}