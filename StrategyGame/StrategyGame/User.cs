using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class User
	{
		private string Name;
		public Colony ActiveColony;
		public Island ActiveIsland;
		public Ship Ship = new Ship();
		public List<Colony> colonies = new List<Colony>();

		public User() { }
		public User(string name, Ship ship)
		{
			Name = name;
			Ship = ship;
		}

		public void SetName(string name)
		{
			Name = name;
		}
		public void SetShip(Ship ship)
		{
			Ship = ship;
		}
	}
}
