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
		List<List<char>> Map { set; }

		event Action LoadingMap;
	}
}
