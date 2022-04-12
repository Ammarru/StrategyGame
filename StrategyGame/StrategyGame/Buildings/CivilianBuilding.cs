using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("StrategyGame.UnitTests")]
namespace StrategyGame
{
	public class CivilianBuilding : Building
	{
		public  int Capacity = 10;
		public List<Worker> workers = new List<Worker>();
		protected string Name = "2. Civilian Building";

		public CivilianBuilding() {  }
		public CivilianBuilding(Warehouse warehouse)
		{
			Warehouse = warehouse;
			UpgradeMultiplier = 1.5m;
			Cost = new Resources(2, 2, 2);
		}
		public void train (int NumOfCivilians)
		{
			if((NumOfCivilians*5)<= Warehouse.Storage.Food)
			{
				if (workers.Count+NumOfCivilians <= Capacity)
				{
					Warehouse.Storage.Subtract(new Resources(NumOfCivilians * 5, 0, 0));
					for (int i = 1; i<= NumOfCivilians; i++)
					{
						workers.Add(new Worker());
					}
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"{NumOfCivilians} workers have been trained.");
					Console.ForegroundColor = color;
				}
				else
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Building's maximum capacity is {Capacity}, please upgrade for more capacity");
					Console.ForegroundColor = color;
				}
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not Enough Food.\nYou need 5 food per civilian, current food in warehouse equals: "+ Warehouse.Storage.Food);
				Console.ForegroundColor = color;
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
				Console.WriteLine("Upgrade succesfull to level: "+Level+"\n New Capacity: "+ Capacity+", Cost to upgrade to level "+ Level+1+" equals :");
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
