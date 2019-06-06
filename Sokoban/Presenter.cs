using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
	class Presenter
	{
		Model model;
		IView view;

		public Presenter(Model model, IView view)
		{
			this.model = model;
			this.view = view;
			this.view.LoadMap += LoadMap;
			this.view.MovePlayerUp += MovePlayerUp;
			this.view.MovePlayerLeft += MovePlayerLeft;
			this.view.MovePlayerRight += MovePlayerRight;
			this.view.MovePlayerDown += MovePlayerDown;
		}

		private void LoadMap()
		{
			view.Map = model.LoadMapFromFile();
		}

		private void MovePlayerUp()
		{
			view.Map = model.MovePlayerUp();
		}

		private void MovePlayerDown()
		{
			model.MovePlayerDown();
		}

		private void MovePlayerLeft()
		{
			model.MovePlayerLeft();
		}

		private void MovePlayerRight()
		{
			model.MovePlayerRight();
		}
	}
}
