using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sokoban
{
	public interface IView
	{
		Map SetMap { set; }
		
		event Action LoadMap;
		event Action ResetMap;
		event Action MovePlayerUp;
		event Action MovePlayerLeft;
		event Action MovePlayerRight;
		event Action MovePlayerDown;
	}
}
