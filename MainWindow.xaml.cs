using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RotateCamLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamHoriz.Text);
            degree--;
            CamHoriz.Text = degree.ToString();
        }

        private void RotateCamRightBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamHoriz.Text);
            degree++;
            CamHoriz.Text = degree.ToString();
        }

        private void RotateCamUpBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamVert.Text);
            degree++;
            CamVert.Text = degree.ToString();
        }

        private void RotateCamDownBtn_Click(object sender, RoutedEventArgs e)
        {
            int degree = Convert.ToInt32(CamVert.Text);
            degree--;
            CamVert.Text = degree.ToString();
        }

        private void MoveLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            MoveLeftBtn.Background = new SolidColorBrush(Colors.Green);
        }

        private void MoveRightBtn_Click(object sender, RoutedEventArgs e)
        {

            MoveRightBtn.Background = new SolidColorBrush(Colors.Green);
        }

        private void MoveForwBtn_Click(object sender, RoutedEventArgs e)
        {

            MoveForwBtn.Background = new SolidColorBrush(Colors.Green);
        }

        private void MoveBackBtn_Click(object sender, RoutedEventArgs e)
        {

            MoveBackBtn.Background = new SolidColorBrush(Colors.Green);
        }
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
            e.CanExecute = true;
        }

        private void MoveForwCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
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