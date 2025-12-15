using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroundDroneApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Gears _gear;
        public MainWindow()
        {
            InitializeComponent();
            _gear = Gears.First;
        }

        private void HandbrakeOffBtn_Click(object sender, RoutedEventArgs e)
        {
            MoveUpBtn.IsEnabled = true;
            MoveDownBtn.IsEnabled = true;
            MoveLeftBtn.IsEnabled = true;
            MoveRightBtn.IsEnabled = true;

            HandbrakeOnBtn.IsEnabled = true;
            HandbrakeOffBtn.IsEnabled = false;
        }

        private void HandbrakeOnBtn_Click(object sender, RoutedEventArgs e)
        {

            MoveUpBtn.IsEnabled = false;
            MoveDownBtn.IsEnabled = false;
            MoveLeftBtn.IsEnabled = false;
            MoveRightBtn.IsEnabled = false;

            HandbrakeOnBtn.IsEnabled = false;
            HandbrakeOffBtn.IsEnabled = true;
        }

        private void GearOneBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.First;

            GearOneBtn.IsEnabled = false;

            GearTwoBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);
        }

        private void GearTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Second;

            GearTwoBtn.IsEnabled = false;

            GearOneBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);
        }

        private void GearThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Third;

            GearThreeBtn.IsEnabled = false;


            GearOneBtn.IsEnabled = true;
            GearTwoBtn.IsEnabled = true;
            GearFourBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: "  + (int)_gear);
        }

        private void GearFourBtn_Click(object sender, RoutedEventArgs e)
        {
            _gear = Gears.Fourth;

            GearFourBtn.IsEnabled = false;


            GearOneBtn.IsEnabled = true;
            GearTwoBtn.IsEnabled = true;
            GearThreeBtn.IsEnabled = true;

            Debug.WriteLine("Gear set to: " + (int)_gear);
        }
    }
}