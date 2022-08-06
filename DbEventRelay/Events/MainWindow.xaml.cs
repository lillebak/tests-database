using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Events
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DbCommandMonitor dbCommandMonitor;
		


		public MainWindow() {
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			dbCommandMonitor = new DbCommandMonitor();
			dbCommandMonitor.StartCommand += dbCommandMonitor_StartCommand;
			dbCommandMonitor.StopCommand += dbCommandMonitor_StopCommand;

		}

		void dbCommandMonitor_StopCommand(object sender, EventArgs e) {
			Console.WriteLine("Stop command received");
		}

		void dbCommandMonitor_StartCommand(object sender, StartCmdEventArgs e) {
			Console.WriteLine("Start command received with argument: " + e.CommandArg);
		}


	}
}
