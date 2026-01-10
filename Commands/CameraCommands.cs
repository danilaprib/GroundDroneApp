using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GroundDroneApp.Commands;

public static class CameraCommands
{
    //public static readonly RoutedUICommand PressCamUp = new RoutedUICommand("PressCamUp", "PressCamUp", typeof(CameraCommands), new InputGestureCollection() { new KeyGesture(Key.Up) });
    //public static readonly RoutedUICommand PressCamDown = new RoutedUICommand("PressCamDown", "PressCamDown", typeof(CameraCommands), new InputGestureCollection() { new KeyGesture(Key.Down) });
    //public static readonly RoutedUICommand PressCamLeft = new RoutedUICommand("PressCamLeft", "PressCamLeft", typeof(CameraCommands), new InputGestureCollection() { new KeyGesture(Key.Left) });
    //public static readonly RoutedUICommand PressCamRight = new RoutedUICommand("PressCamRight", "PressCamRight", typeof(CameraCommands), new InputGestureCollection() { new KeyGesture(Key.Right) });


    public static readonly RoutedUICommand PressCamUp = new RoutedUICommand("PressCamUp", "PressCamUp", typeof(CameraCommands));
    public static readonly RoutedUICommand PressCamDown = new RoutedUICommand("PressCamDown", "PressCamDown", typeof(CameraCommands));
    public static readonly RoutedUICommand PressCamLeft = new RoutedUICommand("PressCamLeft", "PressCamLeft", typeof(CameraCommands));
    public static readonly RoutedUICommand PressCamRight = new RoutedUICommand("PressCamRight", "PressCamRight", typeof(CameraCommands));
}
