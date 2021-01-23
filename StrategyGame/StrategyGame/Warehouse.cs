using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Warehouse 
	{
		public Resources Storage = new Resources();
		private int Capacity = 200;
		private int Level = 1;
		private decimal UpgradeMultiplier = 2.0m;
		private bool Active = false;
		public Warehouse(Resources storage)
		{
			Storage = storage;
		}
		public void Add(Resources source)
		{
			Storage.Food += source.Food;
			Storage.Wood += source.Wood;
			Storage.Stone += source.Stone;
			
		}

		public void Transfer(Ship Ship, Resources Amount)
		{
			if (Storage.Food >= Amount.Food && Storage.Wood >= Amount.Wood && Storage.Stone >= Amount.Stone)
			{
				Ship.Storage.Food += Amount.Food;
				Storage.Food -= Amount.Food;
				Ship.Storage.Stone += Amount.Stone;
				Storage.Stone -= Amount.Stone;
				Ship.Storage.Wood += Amount.Wood;
				Storage.Wood -= Amount.Wood;

				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Amount has been transfered to ship, new ship storage equals: ");
				Ship.Storage.ShowResources();
				Console.ForegroundColor = color;

			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("you don't have enough resources in your Warehouse!\nMaximum amount you can transfer is: ");
				Storage.ShowResources();
				Console.ForegroundColor = color;
			}

		}
	}
}
