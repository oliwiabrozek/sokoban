using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Sokoban
{
	public class Model
	{
		private List<List<char>> map;
		private Point player;
		private List<Point> boxes;
		private int x = -1;
		private int y = -1;

		public Model()
		{
			player = new Point();
			boxes = new List<Point>();
		}

		public List<List<char>> LoadMapFromFile()
		{
			string[] lines = File.ReadAllLines(Application.StartupPath + @"\map.txt");			map = new List<List<char>>();
			foreach (string line in lines)
			{
				x++; //wiersze
				map.Add(line.ToList());

				foreach(char c in line)
				{
					
					if(c == '@')
					{
						player.X = x;
						player.Y = y;
					}
					else if(c == '*')
					{
						boxes.Add(new Point(x, y));
					}
					y++; //kolumny

				}
				y = 0;

			}
			return map;
		}

		public List<List<char>> MovePlayerUp()
		{
			map[player.X][player.Y] = ' ';
			player.X -= 1;
			map[player.X][player.Y] = '@';
			return map;
		}

		public void MovePlayerDown()
		{

		}
		public void MovePlayerLeft()
		{

		}
		public void MovePlayerRight()
		{

		}
	}

}
