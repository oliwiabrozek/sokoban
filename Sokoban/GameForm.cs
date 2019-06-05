using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
	public partial class GameForm : Form, IView
	{
		public GameForm()
		{
			InitializeComponent();
		}

		public event Action LoadingMap;

		public List<List<char>> Map
		{
			//get { return; }
			set {; }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(LoadingMap!=null)
			{
				LoadingMap();
			}
		}
	}
}
