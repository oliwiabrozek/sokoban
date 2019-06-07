using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sokoban
{
	public class Map
	{
		private List<List<char>> map;
		private Point playerXY;
		private Point playerNewXY;
		private Point boxXY;
		private Point boxNewXY;
		private List<Point> boxesXY;
		private bool playerMoveAllowed = true;
		//private bool boxMoveAllowed = true;
		private int x = 0; //rows
		private int y = 0; //columns

		public Map()
		{
			playerXY = new Point();
			playerNewXY = new Point();
			boxXY = new Point();
			boxNewXY = new Point();
			boxesXY = new List<Point>();
		}

		public List<List<char>> MapProperties
		{
			get { return map; }
			set { map = value; }
		}

		public List<List<char>> LoadMapFromFile()
		{
			string[] lines = File.ReadAllLines(Application.StartupPath + @"\map.txt");
			map = new List<List<char>>();
			foreach (string line in lines)
			{
				
				map.Add(line.ToList());

				foreach (char c in line)
				{
					if (c == '@')
					{
						playerXY.X = x;
						playerXY.Y = y;
						playerNewXY.X = x;
						playerNewXY.Y = y;
					}
					else if (c == '*')
					{
						boxesXY.Add(new Point(x, y));
					}
					y++; //kolumn
				}
				y = 0;
				x++; //wiersze
			}
			return map;
		}

		public void changeplayerXYCoordinates(String direction)
		{
			switch(direction)
			{
				case "Up":
					playerNewXY.X -= 1;
					if (map[playerNewXY.X][playerNewXY.Y] == 'X')
						playerMoveAllowed = false;
					break;
				case "Down":
					playerNewXY.X += 1;
					if (map[playerNewXY.X][playerNewXY.Y] == 'X')
						playerMoveAllowed = false;
					break;
				case "Right":
					playerNewXY.Y += 1;
					if (map[playerNewXY.X][playerNewXY.Y] == 'X')
						playerMoveAllowed = false;
					break;
				case "Left":
					playerNewXY.Y -= 1;
					if (map[playerNewXY.X][playerNewXY.Y] == 'X')
						playerMoveAllowed = false;
					//else if (map[playerNewXY.X][playerNewXY.Y] == '*')
					//{
					//	boxXY.X = playerNewXY.X;
					//	boxXY.Y = playerNewXY.Y;

					//	int ind = boxesXY.IndexOf(boxXY);

					//	boxNewXY.X += boxXY.X;
					//	boxNewXY.Y = boxXY.X - 1;

					//	if (map[boxNewXY.X][boxNewXY.Y] == 'X')
					//		playerMoveAllowed = false;
					//	else
					//	{
					//		boxXY.X = boxNewXY.X;
					//		boxXY.Y = boxNewXY.Y;
					//		boxesXY[ind] = boxXY;
					//	}

					//}
					break;
			}
			
		}

		public void updateMap(String direction)
		{
			changeplayerXYCoordinates(direction);
			if (playerMoveAllowed == true)
			{
				map[playerXY.X][playerXY.Y] = ' ';
				map[playerNewXY.X][playerNewXY.Y] = '@';
				playerXY.X = playerNewXY.X;
				playerXY.Y = playerNewXY.Y;
			}
			else
			{
				playerNewXY.X = playerXY.X;
				playerNewXY.Y = playerXY.Y;
			}
			playerMoveAllowed = true;
			
		}


	}
}
