using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GroundDroneApp.Commands;
public static class ApplicationCommands
{
    public static readonly RoutedUICommand KillApp = new RoutedUICommand("KillApp", "KillApp", typeof(ApplicationCommands));
}

