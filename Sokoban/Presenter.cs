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
			this.view.LoadingMap += LoadingMap;
		}

		private void LoadingMap()
		{
			view.Map = model.LoadMap();
		}


	}
}
