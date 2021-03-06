using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class MilitaryBuilding : Building
	{
		//public int capacity = 5;

		//public List<Soldier> soldiers = new List<Soldier>();
		public int soldiers; 
		protected string Name = "3. Military Building";
		public MilitaryBuilding() { }
		public MilitaryBuilding(Warehouse warehouse)
		{
			this.capacity = 5;
			Warehouse = warehouse;
			UpgradeMultiplier = 2.0m;
			Cost = new Resources(5, 5, 5);
		}
		public bool train(int NumOfCivilians)
		{
			if ((NumOfCivilians * 10) <= Warehouse.Storage.Food)
			{
				if (soldiers+NumOfCivilians <= this.capacity)
				{
					Warehouse.Storage.Subtract(new Resources(NumOfCivilians * 10, 0, 0));
					for (int i = 1; i <= NumOfCivilians; i++)
					{
						soldiers++;
					}
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"{NumOfCivilians} soldiers have been trained.");
					Console.ForegroundColor = color;
					return true;
				}
				else
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Building's maximum capacity is {this.capacity}, please upgrade for more capacity");
					Console.ForegroundColor = color;
					return false;
				}
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Not Enough Food.\nYou need 10 food per soldier, current food in warehouse equals: {Warehouse.Storage.Food}");
				Console.ForegroundColor = color;
				return false;
			}
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
		protected internal override void ShowInfo()
		{
			Console.WriteLine(Name);
			base.ShowInfo();
		}
	}
}
