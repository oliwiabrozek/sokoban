using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sokoban
{
	public partial class GameForm : Form, IView
	{
		private Graphics g;

		public GameForm()
		{
			InitializeComponent();
			g = CreateGraphics();
		}

		public Map SetMap
		{
			set
			{
				DrawMap(value);
			}
		}

		public event Action LoadMap;
		public event Action MovePlayerUp;
		public event Action MovePlayerDown;
		public event Action MovePlayerLeft;
		public event Action MovePlayerRight;

		private void DrawMap(Map map)
		{
			int i = -1;
			int j = -1;
			foreach(List<char> line in map.MapProperties)
			{
				j++;
				foreach (char c in line)
				{
					i++;
					switch (c)
					{
						case 'X':
							g.DrawImage(Properties.Resources.wall, i * 32, j * 32);
							break;
						case '@':
							g.DrawImage(Properties.Resources.player, i * 32, j * 32);
							break;
						case '*':
							g.DrawImage(Properties.Resources.box, i * 32, j * 32);
							break;
						case ' ':
							g.DrawImage(Properties.Resources.ground, i * 32, j * 32);
							break;
						case '.':
							g.DrawImage(Properties.Resources.ground, i * 32, j * 32);
							break;
					}
				}
				i = -1;
			}

		}


		private void GameForm_Load(object sender, EventArgs e)
		{
			LoadMap();
		}

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Up:
					MovePlayerUp();
					break;
				case Keys.Down:
					MovePlayerDown();
					break;
				case Keys.Left:
					MovePlayerLeft();
					break;
				case Keys.Right:
					MovePlayerRight();
					break;
			}
		}
	}
}
