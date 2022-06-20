using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Nomad
	{
		public int Number;
		private uint FriendsipLevel=1;
		public Resources Storage;
		private decimal GrowthRate = 1.3m;
		public bool Contracted = false;
		public Nomad(int number, Resources resources)
		{
			Number = number;
			Storage = resources;
		}
		
		public void Contract()
		{
			if (!Contracted)
			{
				if (FriendsipLevel >= 5)
				{
					Contracted = true;
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Contract successful!");
					Console.ForegroundColor = color;
				}
				else if (FriendsipLevel < 5 && FriendsipLevel >= 2)//random chance to win
				{
					Random rng = new Random();
					Contracted = rng.Next(0, 2) > 0;
					if (Contracted)//win
					{
						var color = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Contract successful!");
						Console.ForegroundColor = color;
						Contracted = true;
					}
					else//lose
					{
						var color = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Contract Failed!");
						Console.ForegroundColor = color;
					}
				}
				else if (FriendsipLevel < 2)//definite loss
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Contract Failed!");
					Console.ForegroundColor = color;
				} 
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You already have a contract with those Nomads!");
				Console.ForegroundColor = color;
			}
		}

		public void Fight(int soldiers,User user)
		{
			if (!Contracted)
			{
				if (soldiers > Number)//Win
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("You Won!");
					Storage.Move(user.ActiveColony.Warehouse.Storage, new Resources(Storage.Food / 2, Storage.Wood / 2, Storage.Stone / 2));
					Console.WriteLine("You've Looted: ");
					Storage.ShowResources();
					var militaryBuilding = new MilitaryBuilding();
					militaryBuilding = (MilitaryBuilding)user.ListOfBuildings()[2];
					militaryBuilding.soldiers-=Number;
					Number = 0;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"CASUALTIES\nYou lost {Number} Soldiers.\nThe Nomads Lost all their soldiers");
					Console.ForegroundColor = color;
					FriendsipLevel += 2;
				}
				else if (soldiers == Number)//random chance to win or lose
				{
					Random rng = new Random();
					var win = rng.Next(0, 2) > 0;
					if (win)
					{
						var color = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						Console.WriteLine("It was a tough battle, but in the end you've won. unfortunetly you lost all your soldiers in the process");
						Storage.Move(user.ActiveColony.Warehouse.Storage, new Resources(Storage.Food / 2, Storage.Wood / 2, Storage.Stone / 2));
						Console.WriteLine("You've Looted: ");
						Storage.ShowResources();
						var militaryBuilding = new MilitaryBuilding();
						militaryBuilding = (MilitaryBuilding)user.ListOfBuildings()[2];
						militaryBuilding.soldiers-=soldiers;
						Number = 0;
						Console.ForegroundColor = color;
						FriendsipLevel++;
					}
					else
					{
						var color = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("You Lost.");
						Console.WriteLine($"CASUALTIES\nYou lost all your Soldiers, and so did the Nomads");
						var militaryBuilding = new MilitaryBuilding();
						militaryBuilding = (MilitaryBuilding)user.ListOfBuildings()[2];
						militaryBuilding.soldiers-= soldiers;
						Number = 0;
						Console.ForegroundColor = color;
						FriendsipLevel--;
					}
				}
				else if (soldiers < Number)//Lose
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You Lost.");
					Console.WriteLine($"CASUALTIES\nYou lost all your Soldiers.\nThe Nomads lost {soldiers} soldiers. better luck next time.");
					var militaryBuilding = new MilitaryBuilding();
					militaryBuilding = (MilitaryBuilding)user.ListOfBuildings()[2];
					militaryBuilding.soldiers -= soldiers;
					Number -= soldiers;
					Console.ForegroundColor = color;
					FriendsipLevel--;
				} 
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You're under contract with those nomads, you can not attack them.");
				Console.ForegroundColor = color;
			}
		}
		public void AskForResources(User user)
		{
			if (Contracted)
			{
				Resources gift = new Resources(Storage.Food / 4, Storage.Wood / 4, Storage.Stone / 4);
				Storage.Move(user.ActiveColony.Warehouse.Storage,gift);
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Nomads gave you: ");
				gift.ShowResources();
				Console.ForegroundColor = color;
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Those Nomads don't like you very much.");
				Console.ForegroundColor = color;
			}
		}

		public void SkipDay()
		{
			if (Number == 0) Number = 1;
			Number *= (int)(GrowthRate * 2.5m);
			Storage.increament(GrowthRate);

		}

		
		
	}
}
