using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			GameEngine gameEngine = new GameEngine();
			IView view = new GameForm();
			Presenter presenter = new Presenter(gameEngine, view);

			Application.Run((Form)view);
		}
	}
}
