using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Island
	{
		private string Name;
		public Colony Colony;
		public Nomad Nomads;
		public  Resources Resources = new Resources(100, 100, 100);
		private decimal GrowthRate = 1.2m;

		public Island(string name, Colony colony, Nomad nomads)
		{
			Name = name;
			Colony = colony;
			Nomads = nomads;
			
		}

		public Island(string name, Colony colony, Nomad nomads, Resources resources) : this(name, colony, nomads)
		{
			Resources = resources;
		}

		public Island(string name, Colony colony, Nomad nomads, Resources resources, decimal growthRate) : this(name, colony, nomads, resources)
		{
			GrowthRate = growthRate;
		}

		public void SkipDay()
		{
			
			Nomads.SkipDay();
			Resources.increament(GrowthRate);
		}

		public void ChangeName(string name)
		{
			Name = name;
			Console.WriteLine($"Name has been successfuly changed to {Name}");
		}

		public void DisplayToConsole()
		{
			Console.WriteLine($"{Name} info:");
			Console.WriteLine($"Number of Nomads on the island : {Nomads.Number}, Nomads resources: ");
			Nomads.Storage.ShowResources();
			Console.WriteLine("Colony status: free");
			Colony.ColonyInfo();
			
		}
	}
}
