using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GroundDroneApp.Commands;

public static class TracksCommands
{
    public static readonly RoutedUICommand MoveForw = new RoutedUICommand("MoveForw", "MoveForw", typeof(TracksCommands));
    public static readonly RoutedUICommand MoveBack = new RoutedUICommand("MoveBack", "MoveBack", typeof(TracksCommands));
    public static readonly RoutedUICommand MoveLeft = new RoutedUICommand("MoveLeft", "MoveLeft", typeof(TracksCommands));
    public static readonly RoutedUICommand MoveRight = new RoutedUICommand("MoveRight", "MoveRight", typeof(TracksCommands));
}
