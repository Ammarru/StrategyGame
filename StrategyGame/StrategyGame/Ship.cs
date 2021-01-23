using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Ship
	{
		public string Name = "Shelly";
		public Resources Storage;

		public Ship() { Storage = new Resources(0, 0, 0); }
		public Ship(String name,Resources resources)
		{
			Storage = resources;
			Name = name;
		}

		public void Transfer(Warehouse warehouse,Resources Amount)
		{
			if (Storage.Food >= Amount.Food && Storage.Wood >= Amount.Wood && Storage.Stone >= Amount.Stone)
			{
				warehouse.Storage.Food += Amount.Food;
				Storage.Food -= Amount.Food;
				warehouse.Storage.Stone += Amount.Stone;
				Storage.Stone -= Amount.Stone;
				warehouse.Storage.Wood += Amount.Wood;
				Storage.Wood -= Amount.Wood;
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Amount has been transfered to Warehouse, new warehouse storage equals: ");
				warehouse.Storage.ShowResources();
				Console.ForegroundColor = color;
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("you don't have enough resources in your Ship!\nMaximum amount you can transfer is: ");
				Storage.ShowResources();
				Console.ForegroundColor = color;
			}
		}

		public void ChangeName(string name)
		{
			Name = name;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"Name: {Name}.\nResources: ");
			Storage.ShowResources();
		}
	}
}
