using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
	class Presenter
	{
		GameEngine gameEngine;
		IView view;

		public Presenter(GameEngine gameEngine, IView view)
		{
			this.gameEngine = gameEngine;
			this.view = view;
			this.view.LoadMap += LoadMap;
			this.view.ResetMap += ResetMap;
			this.view.MovePlayerUp += MovePlayerUp;
			this.view.MovePlayerLeft += MovePlayerLeft;
			this.view.MovePlayerRight += MovePlayerRight;
			this.view.MovePlayerDown += MovePlayerDown;
		}

		private void LoadMap()
		{
			view.SetMap = gameEngine.GetMap();
			
		}
		private void ResetMap()
		{
			gameEngine = new GameEngine();
		}

		private void MovePlayerUp()
		{
			gameEngine.MovePlayerUp();
			view.SetMap = gameEngine.GetMap();
		}

		private void MovePlayerDown()
		{
			gameEngine.MovePlayerDown();
			view.SetMap = gameEngine.GetMap();
		}

		private void MovePlayerLeft()
		{
			gameEngine.MovePlayerLeft();
			view.SetMap = gameEngine.GetMap();
		}

		private void MovePlayerRight()
		{
			gameEngine.MovePlayerRight();
			view.SetMap = gameEngine.GetMap();
		}
	}
}
