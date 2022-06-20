using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class ProductionBuilding : Building
	{
		public Resources Storage = new Resources();
		//public int capacity;
		protected string Name = "1. Production Building";

		public ProductionBuilding()
		{
			
		}

		public ProductionBuilding(Warehouse warehouse)
		{
			this.capacity = 40;
			Storage = new Resources(this.capacity, this.capacity, this.capacity);
			UpgradeMultiplier = 1.5m;
			Warehouse = warehouse;
			Cost = new Resources(2, 2, 2);
		}

		protected internal override void Upgrade()
		{
			if (Warehouse.Storage.Food >= Cost.Food && Warehouse.Storage.Wood >= Cost.Wood && Warehouse.Storage.Stone >= Cost.Stone)
			{
				Warehouse.Storage.Subtract(Cost);
				Level++;
				Cost.increament(UpgradeMultiplier * Level);
				this.capacity = (int)(this.capacity * UpgradeMultiplier);
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Upgrade succesfull to level: " + Level + "\n New capacity: " + this.capacity + ", Cost to upgrade to level " + Level + 1 + " equals :");
				Cost.ShowResources();
				Console.ForegroundColor = color;
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Insufficent resources!");
				Console.ForegroundColor = color;
			}

		}
		public void SkipDay()//Collect resources
		{
			Warehouse.Add(Storage);
		}
		protected internal override void ShowInfo()
		{
			Console.WriteLine(Name);
			base.ShowInfo();
		}
	}
}
