using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class MilitaryBuilding : Building
	{
		public int Capacity = 5;
		public List<Soldier> soldiers = new List<Soldier>();
		protected string Name = "3. Military Building";
		public MilitaryBuilding() { }
		public MilitaryBuilding(Warehouse warehouse)
		{
			Warehouse = warehouse;
			UpgradeMultiplier = 2.0m;
			Cost = new Resources(5, 5, 5);
		}
		public bool train(int NumOfCivilians)
		{
			if ((NumOfCivilians * 10) <= Warehouse.Storage.Food)
			{
				if (soldiers.Count+NumOfCivilians <= Capacity)
				{
					Warehouse.Storage.Subtract(new Resources(NumOfCivilians * 10, 0, 0));
					for (int i = 1; i <= NumOfCivilians; i++)
					{
						soldiers.Add(new Soldier());
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
					Console.WriteLine($"Building's maximum capacity is {Capacity}, please upgrade for more capacity");
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
				Capacity = (int)(Capacity * UpgradeMultiplier);
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Upgrade succesfull to level: " + Level + "\n New Capacity: " + Capacity + ", Cost to upgrade to level " + Level + 1 + " equals :");
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
