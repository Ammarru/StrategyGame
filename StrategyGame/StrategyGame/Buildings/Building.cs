using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("StrategyGame.UnitTests")]
namespace StrategyGame
{
	public abstract class Building
	{
		public int Level;
		protected decimal UpgradeMultiplier;
		protected Resources Cost;
		protected Warehouse Warehouse;
		
		public bool Active = false;

		protected Building(Warehouse warehouse)
		{
			Warehouse = warehouse;
		}

		protected Building()
		{
		}

		internal virtual void Build()
		{
			if (Warehouse.Storage.Food >= Cost.Food && Warehouse.Storage.Wood >= Cost.Wood 
				&& Warehouse.Storage.Stone >= Cost.Stone)
			{
				Warehouse.Storage.Subtract(Cost);
				Level = 1;
				Cost.increament(UpgradeMultiplier*Level);
				Active = true;
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Building has been successfully built!");
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
		protected internal virtual void Upgrade()
		{
			if (Warehouse.Storage.Food >= Cost.Food && Warehouse.Storage.Wood >= Cost.Wood && Warehouse.Storage.Stone >= Cost.Stone)
			{
				Warehouse.Storage.Subtract(Cost);
				Level ++;
				Cost.increament(UpgradeMultiplier*Level);
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Insufficent resources!");
				Console.ForegroundColor = color;
			}
		}
		protected internal virtual void ShowInfo()
		{
			
			Console.WriteLine($"Cost to build/upgrade:");
			Cost.ShowResources();
			Console.WriteLine("..............................");
		}
	}
}
