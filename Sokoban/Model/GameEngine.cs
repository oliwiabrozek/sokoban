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
	public class GameEngine
	{
		Map map;

		public GameEngine()
		{
			map = new Map();
			map.LoadMapFromFile();
		}

		public Map GetMap()
		{
			return map;
		}
		public void MovePlayerUp()
		{
			map.updateMap("Up");
		}

		public void MovePlayerDown()
		{
			map.updateMap("Down");
		}
		public void MovePlayerLeft()
		{
			map.updateMap("Left");
		}
		public void MovePlayerRight()
		{
			map.updateMap("Right");
		}
	}

}
