using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Colony
	{
		public Warehouse Warehouse;
		public List<Building> Buildings ;
		private string Name;
		public bool Active = false;
		public Colony(Warehouse warehouse,string name)
		{
			Warehouse = warehouse;
			Buildings = new List<Building> {new ProductionBuilding(warehouse), new CivilianBuilding(warehouse), new MilitaryBuilding(warehouse) };
			Name = name;
		}

		public void SkipDay()
		{
			foreach(var i in Buildings)
			{
				if (i is ProductionBuilding&&i.Active)
				{
					var j = new ProductionBuilding();
					j = (ProductionBuilding)i;
					j.SkipDay();
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Resources have been collected from production building in Colony \"{Name}\", and moved to the warehouse");
					Console.ForegroundColor = color;

				}
			}
		}
		public void ColonyInfo()
		{
			Console.WriteLine($"Colony info:\nName: {Name}\nAvailable resources at Warehouse: ");
			Warehouse.Storage.ShowResources();
			Console.WriteLine($"Built Buildings: \n- Warehouse");
		
			foreach (var i in Buildings)
			{
				if (i is ProductionBuilding&&i.Active)
				{
					Console.WriteLine($"- Production Building, level : {i.Level}");
				}
				else if(i is CivilianBuilding&&i.Active)
				{
					var j = new CivilianBuilding();
					j = (CivilianBuilding)i;
					Console.WriteLine($"- Civilian Building, level : {i.Level}, Number of Civilians: {j.workers.Count}");
				}
				else if (i is MilitaryBuilding && i.Active)
				{
					var j = new MilitaryBuilding();
					j = (MilitaryBuilding)i;
					Console.WriteLine($"- Military Building, level : {i.Level}, Number of Soldiers: {j.soldiers.Count}");
				}
			}
		}
		public void BuildingsDetails()
		{
			foreach (var i in Buildings)
			{
				if (i is ProductionBuilding && i.Active)
				{
					var j = new ProductionBuilding();
					j = (ProductionBuilding)i;
					Console.WriteLine($"- Production Building, level : {i.Level}, Capacity: {j.Capacity}");
				}
				else if (i is CivilianBuilding && i.Active)
				{
					var j = new CivilianBuilding();
					j = (CivilianBuilding)i;
					Console.WriteLine($"- Civilian Building, level : {i.Level}, Number of Civilians: {j.workers.Count}, Capacity: {j.Capacity}");
				}
				else if (i is MilitaryBuilding && i.Active)
				{
					var j = new MilitaryBuilding();
					j = (MilitaryBuilding)i;
					Console.WriteLine($"- Military Building, level : {i.Level}, Number of Soldiers: {j.soldiers.Count}, Capacity: {j.Capacity}");
				}
			}
		}
		public bool HasProductionBuilding()
		{
			if (Buildings[0].Active) return true;
			else return false;
		}
		public bool HasCivilianBuilding()
		{
			if (Buildings[1].Active) return true;
			else return false;
		}
		public bool HasMilitaryBuilding()
		{
			if (Buildings[2].Active) return true;
			else return false;
		}
		public int NumberOfWorkers()
		{
			
				var i = new CivilianBuilding();
				i = (CivilianBuilding)Buildings[0];
				return i.workers.Count;
			
		}
		public int NumberOfSoldiers()
		{

			var i = new MilitaryBuilding();
			i = (MilitaryBuilding)Buildings[2];
			return i.soldiers.Count;

		}
		public void ChangeName(string name)
		{
			Name = name;
		}
	}
}
