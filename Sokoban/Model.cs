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

		public List<List<char>> LoadMap()
		{
			string[] lines = File.ReadAllLines(Application.StartupPath + @"\map.txt");
			int rows = File.ReadAllLines(Application.StartupPath + @"\map.txt").Count();
			List<List<char>> map = new List<List<char>>();
			
			foreach(string line in lines)
			{
				map.Add(line.ToList());
			}
			return map;
		}

		public void DrawMap(List<List<char>> map)
		{

		}

	}
}
