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
using System.Timers;

namespace Sokoban
{
	public partial class GameForm : Form, IView
	{
		private Graphics g;
		private Bitmap currentPlayerBitmap = Properties.Resources.player_down;
		private int width;
		private int tempWidth;
		private int height;
		private System.Timers.Timer timer;
		private int h, m, s;
		
		public GameForm()
		{
			InitializeComponent();
			//KeyDown += new KeyEventHandler(GameForm_KeyDown);
			timer = new System.Timers.Timer();
		}

		

		private void OnTimeEvent(object sender, ElapsedEventArgs e)
		{
			//throw new NotImplementedException();
			Invoke (new Action(() =>
			{
				s += 1;
				if (s == 60)
				{
					s = 0;
					m += 1;
				}
				if(m==60)
				{
					m = 0;
					h += 1;
				}
				label2.Text = String.Format("Time: {0}:{1}:{2}", h.ToString().PadLeft(2,'0'),
					m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
			}));
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
		public event Action ResetMap;

		private void DrawMap(Map map)
		{
			width = 0;
			height = 0;
			
			foreach(List<char> line in map.MapProperties)
			{ 
				foreach (char c in line)
				{
					
					switch (c)
					{
						case 'X':

							g.DrawImage(Properties.Resources.wall, width * 32, height * 32);
							break;
						case '@':
							currentPlayerBitmap.MakeTransparent(Color.Transparent);
							g.DrawImage(Properties.Resources.ground, width * 32, height * 32);
							g.DrawImage(currentPlayerBitmap, width * 32, height * 32);
							break;
						case '*':
							g.DrawImage(Properties.Resources.box, width * 32, height * 32);
							break;
						case ' ':
							g.DrawImage(Properties.Resources.ground, width * 32, height * 32);
							break;
						case '.':
							g.DrawImage(Properties.Resources.destination, width * 32, height * 32);
							break;
					}
					width++;
				}
				height++;
				tempWidth = width;
				width = 0;
			}

			panel1.Width = tempWidth * 32;
			panel1.Height = height * 32;

			label1.Text = "Moves: " + map.MovesCounter;

			if (map.checkIfBoxesDelivered()==true)
			{
				MessageBox.Show("Wygrałeś!!!");
				timer.Stop();
				ResetMap();
				LoadMap();
			}

		}



		private void GameForm_Load(object sender, EventArgs e)
		{
			//LoadMap();
			timer.Interval = 1000;
			timer.Start();
			timer.Elapsed += OnTimeEvent;

		}

		private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer.Stop();
			Application.DoEvents();
		}

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			MessageBox.Show("");

			switch (e.KeyCode)
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

		private void button1_Click(object sender, EventArgs e)
		{
			ResetMap();
			LoadMap();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Up:
					currentPlayerBitmap = Properties.Resources.player_up;
					MovePlayerUp();
					break;
				case Keys.Down:
					currentPlayerBitmap = Properties.Resources.player_down;
					MovePlayerDown();
					break;
				case Keys.Left:
					currentPlayerBitmap = Properties.Resources.player_left;
					MovePlayerLeft();
					break;
				case Keys.Right:
					currentPlayerBitmap = Properties.Resources.player_right;
					MovePlayerRight();
					break;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			g = panel1.CreateGraphics();
			//g = CreateGraphics();
			LoadMap();
			
		}
	}
}
