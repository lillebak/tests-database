using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
	class DbCommandMonitor
	{
		public event EventHandler<StartCmdEventArgs> StartCommand;
		public event EventHandler StopCommand;


		private Timer SendNewCommandTimer;

		private Random random = new Random();


		public DbCommandMonitor() {
			SendNewCommandTimer = new Timer(SendNewCommand, null, 0, 5000);
		}

		private void SendNewCommand(object obj) {
			if (random.Next() % 2 == 1) {
				StopCommand(this, null);
			} else {
				StartCommand(this, new StartCmdEventArgs("DoThis"));
			}
		}



	}


	public class StartCmdEventArgs : EventArgs
	{
		public string CommandArg { get; internal set; }
		public StartCmdEventArgs(string newCmdArgs) {
			this.CommandArg = newCmdArgs;
		}
	}

}
