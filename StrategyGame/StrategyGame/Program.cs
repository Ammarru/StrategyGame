using System;
using System.Collections.Generic;

namespace StrategyGame
{
	class Program
	{


		static void Main(string[] args)
		{
			List<Island> islands = new List<Island> {
					new Island("Island one",new Colony(new Warehouse(new Resources(1000,20,20)),"Colony one"),new Nomad(10,new Resources(50,50,50))),
					new Island("Island Two",new Colony(new Warehouse(new Resources(400,30,30)),"Colony two"),new Nomad(15,new Resources(70,70,70))),
					new Island("Island Three",new Colony(new Warehouse(new Resources(10,10,10)),"Colony three"),new Nomad(5,new Resources(50,50,50))),
					new Island("Island four",new Colony(new Warehouse(new Resources(100,100,100)),"Colony four"),new Nomad(30,new Resources(120,120,120)))
				};
			User user = new User();
			
			Console.WriteLine("Name: ");
			var name = Console.ReadLine();
			user.SetName(name);
			Console.WriteLine("Mode:\n1.Player\n2.Manager");
			var Command = Convert.ToInt32(Console.ReadLine());
			if (Command == 1)
				MainMenu(islands);
			else if (Command == 2) Manager();
			

			void ColonyMenu(User user)
			{
				Console.Clear();
				user.ActiveColony.ColonyInfo();
				Console.WriteLine(
					"1- build new building." +
					"\n2 – upgrade building." +
					"\n3 – view building details." +
					"\n4 – train workers." +
					"\n5 – train soldiers." +
					"\n6 -Transfer resources to Warehouse."+
					"\n7 -Transfer resources to ship." +
					"\n8 -Attack Nomads." +
					"\n9 -Contract Nomads." +
					"\n10 -Ask Nomads for resources"+
					"\n11 -return to Main Menu");
				var command = Convert.ToInt32(Console.ReadLine());

				switch (command)
				{
					case 1:
						Console.Clear();
						var counter = 0;
						foreach (var i in user.ActiveColony.Buildings)
						{
							if (i.Active==false)
							{
								counter++; 
							}
							
						}
						if (counter > 0)
						{
							
							foreach (var i in user.ActiveColony.Buildings)
							{
								
								if (i.Active == false)
								{
									if (i is ProductionBuilding)
									{										
										i.ShowInfo();
									}
									else if (i is CivilianBuilding)
									{
										i.ShowInfo();
									}
									else if (i is MilitaryBuilding)
									{
										i.ShowInfo();
									}
									
								}
								

							}

							var key = Convert.ToInt32(Console.ReadLine());
							switch (key)
							{
								case 1:
									if (user.ActiveColony.HasProductionBuilding() == false)
									{
										if (user.ActiveColony.HasCivilianBuilding())
										{
											user.ActiveColony.Buildings[0].Build();
											wait();
										}
										else
										{
											var color = Console.ForegroundColor;
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("You need to have a Civilian building built before doing that.");
											Console.ForegroundColor = color;
											wait();
										} 
									}
									else
									{
										var color = Console.ForegroundColor;
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("You already have a production building in your Colony!");
										Console.ForegroundColor = color;
										wait();
									}
									break;
								case 2:
									if (user.ActiveColony.HasCivilianBuilding()==false)
									{
										user.ActiveColony.Buildings[1].Build();
										wait();
									}
									else
									{
										var color = Console.ForegroundColor;
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("You already have a Civilian building in your Colony!");
										Console.ForegroundColor = color;
										wait();
									}
									break;
								case 3:
									if (user.ActiveColony.HasMilitaryBuilding()==false)
									{
										if (user.ActiveColony.HasCivilianBuilding())
										{
											user.ActiveColony.Buildings[2].Build();
											wait();
										}
										else
										{
											var color = Console.ForegroundColor;
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine("You need to have a Civilian building built before doing that.");
											Console.ForegroundColor = color;
											wait();
										} 
									}
									else
									{
										var color = Console.ForegroundColor;
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("You already have a Military building building in your Colony!");
										Console.ForegroundColor = color;
										wait();
									}
									break;

							}

						}
						else
						{
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("No more availabe building to build!");
							Console.ForegroundColor = color;
							wait();
						}
						break;
					case 2:
						Console.Clear();
						counter = 0;
						foreach (var i in user.ActiveColony.Buildings)
						{
							if (i.Active)
							{
								counter++;
							}

						}
						if (counter > 0)
						{
							
							foreach (var i in user.ActiveColony.Buildings)
							{
								if (i.Active)
								{
									if (i is ProductionBuilding)
									{
										i.ShowInfo();
									}
									else if (i is CivilianBuilding)
									{
										i.ShowInfo();
									}
									else if (i is MilitaryBuilding)
									{			
										i.ShowInfo();
									} 
								}
							}

							var key = Convert.ToInt32(Console.ReadLine());
							switch (key)
							{
								case 1:
									user.ActiveColony.Buildings[0].Upgrade();
									Console.WriteLine("Press any Key to go to menu");
									Console.ReadKey();
									ColonyMenu(user);
									break;
								case 2:
									user.ActiveColony.Buildings[1].Upgrade();
									Console.WriteLine("Press any Key to go to menu");
									Console.ReadKey();
									ColonyMenu(user);
									break;
								case 3:
									user.ActiveColony.Buildings[2].Upgrade();
									Console.WriteLine("Press any Key to go to menu");
									Console.ReadKey();
									ColonyMenu(user);
									break;

							}

						}
						else
						{
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("No availabel buiding to upgrade, please buildsome buildings first!");
							Console.ForegroundColor = color;
							wait();
						}
						break;
					case 3:
						Console.Clear();
						user.ActiveColony.ColonyInfo();
						Console.WriteLine("Press any Key to go to menu");
						Console.ReadKey();
						ColonyMenu(user);
						break;
					case 4:
						Console.Clear();
						if (user.ActiveColony.HasCivilianBuilding())
						{
							Console.WriteLine("How many workers would you like to train?");
							var number = Convert.ToInt32(Console.ReadLine());
							var cast = new CivilianBuilding();
							cast = (CivilianBuilding)user.ActiveColony.Buildings[1];
							cast.train(number);
							wait();
						}
						else
						{
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("You need a civilian building to be able to train workers.");
							Console.ForegroundColor = color;
							wait();
						}
						break;
					case 5:
						Console.Clear();
						if (user.ActiveColony.HasMilitaryBuilding())
						{
							Console.WriteLine("How many soldiers would you like to train?");
							var number = Convert.ToInt32(Console.ReadLine());
							var civilianBuilding = new CivilianBuilding();
							civilianBuilding = (CivilianBuilding)user.ActiveColony.Buildings[1];
							if (number<= civilianBuilding.workers.Count)
							{
								var militaryBuilding = new MilitaryBuilding();
								militaryBuilding = (MilitaryBuilding)user.ActiveColony.Buildings[2];
								if (militaryBuilding.train(number))
								{
									civilianBuilding.workers.RemoveRange(0, number);
									wait();
								}
								else
									wait();
							}
							else
							{
								var color = Console.ForegroundColor;
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine($"Not enough workers. you currently only have {civilianBuilding.workers.Count} workers");
								Console.ForegroundColor = color;
								wait();
							}
						}
						else
						{
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("You need a military building to be able to train soldiers.");
							Console.ForegroundColor = color;
							wait();
						}
						break;
					case 6:
						Console.Clear();
						Console.WriteLine("Food: ");
						var food = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Wood: ");
						var wood = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Stone: ");
						var stone = Convert.ToInt32(Console.ReadLine());
						var resources = new Resources(food, wood, stone);
						user.Ship.Transfer(user.ActiveColony.Warehouse, resources);
						wait();
						break;
					case 7:
						Console.Clear();
						Console.WriteLine("Food: ");
						food = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Wood: ");
						wood = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Stone: ");
						stone = Convert.ToInt32(Console.ReadLine());
						resources = new Resources(food, wood, stone);
						user.ActiveColony.Warehouse.Transfer(user.Ship, resources);
						wait();
						break;
					case 8:
						Console.Clear();
						Console.WriteLine("How many soldiers you want to assign for the attack?");
						var soldiers = Convert.ToInt32(Console.ReadLine());
						if (soldiers <= user.ActiveColony.NumberOfSoldiers())
						{
							user.ActiveIsland.Nomads.Fight(soldiers,user);
							Console.WriteLine("Press any Key to go to menu");
							Console.ReadKey();
							ColonyMenu(user);
						}
						else
						{
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine($"You don't have enough soldiers.\nCurrent soldier count: {user.ActiveColony.NumberOfSoldiers()}");
							Console.ForegroundColor = color;
							wait();
						}
						break;
					case 9:
						user.ActiveIsland.Nomads.Contract();
						wait();
						break;
					case 10:
						user.ActiveIsland.Nomads.AskForResources(user);
						Console.WriteLine("Press any Key to go to menu");
						Console.ReadKey();
						ColonyMenu(user);
						break;
					case 11:
						MainMenu(islands);
						break;
				}
			}
			void wait()
			{
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("going back to main menu in\n3");
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("2");
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("1");
				System.Threading.Thread.Sleep(1000);
				ColonyMenu(user);
			}
			void MainMenu(List<Island> islands)
			{
				Console.Clear();
				writeInCenter($"Welcome {name} to Strategy Game.\n\n");
				Console.WriteLine($"your ship \"{user.Ship.Name}\" has sailed to the shores of the islands.");
				Console.WriteLine(
					"\n“Q” button – Choose a colony" +
					"\n“R” button – Choose a colony to set active" +
					"\n“E” button – change user name." +
					"\n“C” button – change ship name." +
					"\n“W” button – Show Ship details." +
					"\n“S” button – Skip Day." +
					"\n“M” button – Manager Mode." +
					"\n“ESC” button -Close shop!");
				
				
				var controller = false;
				while (!controller)
				{

					switch (Console.ReadKey().Key)
					{
						case ConsoleKey.Q:

							Console.Clear();
							var n = 1;
							foreach (var i in islands)
							{
								
								
								Console.WriteLine(n + ".");
								i.DisplayToConsole();
								Console.WriteLine("................................");
							
								n++;
							}
							Console.WriteLine("Type number to capture colony");
							var command = Convert.ToInt32(Console.ReadLine());
							switch (command)
							{
								case 1:
									if (islands[0].Colony.Active == false)
									{
										user.ActiveIsland = islands[0];
										user.ActiveColony = islands[0].Colony;
										user.colonies.Add(islands[0].Colony);
										islands[0].Colony.Active = true;
										ColonyMenu(user); 
									}
									else
									{
										user.ActiveIsland = islands[0];
										user.ActiveColony = islands[0].Colony;
										ColonyMenu(user);
									}
									break;
								case 2:
									if (islands[1].Colony.Active == false)
									{
										user.ActiveIsland = islands[1];
										user.ActiveColony = islands[1].Colony;
										user.colonies.Add(islands[1].Colony);
										islands[1].Colony.Active = true;
										ColonyMenu(user);
									}
									else
									{
										user.ActiveIsland = islands[1];
										user.ActiveColony = islands[1].Colony;
										ColonyMenu(user);
									}
									break;
								case 3:
									if (islands[2].Colony.Active == false)
									{
										user.ActiveIsland = islands[2];
										user.ActiveColony = islands[2].Colony;
										user.colonies.Add(islands[2].Colony);
										islands[2].Colony.Active = true;
										ColonyMenu(user);
									}
									else
									{
										user.ActiveIsland = islands[2];
										user.ActiveColony = islands[2].Colony;
										ColonyMenu(user);
									}
									break;
								case 4:
									if (islands[3].Colony.Active == false)
									{
										user.ActiveIsland = islands[3];
										user.ActiveColony = islands[3].Colony;
										user.colonies.Add(islands[3].Colony);
										islands[0].Colony.Active = true;
										ColonyMenu(user);
									}
									else
									{
										user.ActiveIsland = islands[3];
										user.ActiveColony = islands[3].Colony;
										ColonyMenu(user);
									}
									break;
							}
							break;

						case ConsoleKey.S:
							Console.Clear();
							foreach(var i in user.colonies)
							{
								i.SkipDay();
							}
							foreach(var i in islands)
							{
								i.SkipDay();
							}
							var color = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Nomads resources and numbers have increased on all islands.");
							Console.ForegroundColor = color;
							Time.Day++;
							Console.WriteLine("Press any Key to go back");
							Console.ReadKey();
							MainMenu(islands);
							break;

						case ConsoleKey.M:
							Manager();
							break;

						case ConsoleKey.R:
							Console.Clear();
							if (user.colonies.Count < 1)
							{
								color = Console.ForegroundColor;
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine($"you haven't invaded any colonies yet");
								Console.ForegroundColor = color;
								Console.WriteLine("Press any Key to go back");
								Console.ReadKey();
								MainMenu(islands);
							}
							else
							{
								n = 1;
								foreach(var i in user.colonies)
								{
									Console.WriteLine(n+".");
									i.ColonyInfo();
									n++;
								}
								command = Convert.ToInt32(Console.ReadLine());
								switch (command)
								{
									case 1:
										user.ActiveColony = user.colonies[0];
										ColonyMenu(user);
										break;
									case 2:
										user.ActiveColony = user.colonies[1];
										ColonyMenu(user);
										break;
									case 3:
										user.ActiveColony = user.colonies[2];
										ColonyMenu(user);
										break;
									case 4:
										user.ActiveColony = user.colonies[3];
										ColonyMenu(user);
										break;
								}
							}
							break;



						case ConsoleKey.E:
							Console.Clear();
							Console.WriteLine("What Name would you like to change to");
							var name = Console.ReadLine();
							user.SetName(name);
							Console.WriteLine($"Name has been successfuly changed to {name}");
							Console.WriteLine("Press any Key to go back");
							Console.ReadKey();
							MainMenu(islands);
							break;



						case ConsoleKey.C:
							Console.Clear();
							Console.WriteLine("What Name would you like to change to");
							var shipName = Console.ReadLine();
							user.Ship.ChangeName(shipName);
							Console.WriteLine($"Name has been successfuly changed to {shipName}");
							Console.WriteLine("Press any Key to go back");
							Console.ReadKey();
							MainMenu(islands);
							break;

						case ConsoleKey.Escape://Exit
							Console.Clear();
							Console.WriteLine(" TThank you for playing! ");
							System.Threading.Thread.Sleep(500);
							controller = true;
							break;

						case ConsoleKey.W:
							Console.Clear();
							user.Ship.ShowInfo();
							Console.WriteLine("Press any Key to go back");
							Console.ReadKey();
							MainMenu(islands);

							break;

					}

				}
			}
			void Manager()
			{
				Console.Clear();
				var controller = false;
				while (!controller)
				{
					Console.WriteLine("1.Change default building.\n2.Change base capacity of production buildings\n3.Player Mode");
					var Command = Convert.ToInt32(Console.ReadLine());
					switch (Command)
					{
						case 1:
							Console.Clear();
							Console.WriteLine("choose Colony you want to change default buildings for:");
							var n = 1;
							foreach (var i in islands)
							{
								Console.WriteLine(n + ".");
								i.Colony.ColonyInfo();
								n++;
							}
							Command = Convert.ToInt32(Console.ReadLine());
							switch (Command)
							{
								case 1:
									Console.Clear();
									Console.WriteLine("Which building would you like to change?\n1.Production Building\n2.Civilian Building\n3.MilitaryBuilding");
									Command = Convert.ToInt32(Console.ReadLine());
									switch (Command)
									{
										case 1:
											Console.Clear();
											islands[0].Colony.Buildings[0].Active = !(islands[1].Colony.Buildings[0].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 2:
											Console.Clear();
											islands[0].Colony.Buildings[1].Active = !(islands[1].Colony.Buildings[1].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 3:
											Console.Clear();
											islands[0].Colony.Buildings[2].Active = !(islands[1].Colony.Buildings[2].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
									}
									break;
								case 2:
									Console.Clear();
									Console.WriteLine("Which building would you like to change?\n1.Production Building\n2.Civilian Building\n3.MilitaryBuilding");
									Command = Convert.ToInt32(Console.ReadLine());
									switch (Command)
									{
										case 1:
											Console.Clear();
											islands[1].Colony.Buildings[0].Active = !(islands[1].Colony.Buildings[0].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 2:
											Console.Clear();
											islands[1].Colony.Buildings[1].Active = !(islands[1].Colony.Buildings[1].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 3:
											Console.Clear();
											islands[1].Colony.Buildings[2].Active = !(islands[1].Colony.Buildings[2].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
									}
									break;
								case 3:
									Console.Clear();
									Console.WriteLine("Which building would you like to change?\n1.Production Building\n2.Civilian Building\n3.MilitaryBuilding");
									Command = Convert.ToInt32(Console.ReadLine());
									switch (Command)
									{
										case 1:
											Console.Clear();
											islands[2].Colony.Buildings[0].Active = !(islands[2].Colony.Buildings[0].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 2:
											Console.Clear();
											islands[2].Colony.Buildings[1].Active = !(islands[2].Colony.Buildings[1].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 3:
											Console.Clear();
											islands[2].Colony.Buildings[2].Active = !(islands[2].Colony.Buildings[2].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
									}
									break;
								case 4:
									Console.Clear();
									Console.WriteLine("Which building would you like to change?\n1.Production Building\n2.Civilian Building\n3.MilitaryBuilding");
									Command = Convert.ToInt32(Console.ReadLine());
									switch (Command)
									{
										case 1:
											Console.Clear();
											islands[3].Colony.Buildings[0].Active = !(islands[3].Colony.Buildings[0].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 2:
											Console.Clear();
											islands[3].Colony.Buildings[1].Active = !(islands[3].Colony.Buildings[1].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
										case 3:
											Console.Clear();
											islands[3].Colony.Buildings[2].Active = !(islands[3].Colony.Buildings[2].Active);
											Console.WriteLine("Building availability has been switched");
											Console.WriteLine("Press any key to go back");
											Console.ReadKey();
											Manager();
											break;
									}
									break;
							}
							break;
						case 2:
							Console.Clear();
							Console.WriteLine("choose Colony you want to change production cpacityy for for:");
							n = 1;
							foreach (var i in islands)
							{
								Console.WriteLine(n + ".");
								i.Colony.ColonyInfo();
								n++;
							}
							Command = Convert.ToInt32(Console.ReadLine());
							switch (Command)
							{
								case 1:
									Console.Clear();
									var productionBuilding = new ProductionBuilding();
									productionBuilding = (ProductionBuilding)islands[0].Colony.Buildings[0];
									Console.WriteLine("What capacity you want to set?");
									var capacity = Convert.ToInt32(Console.ReadLine());
									productionBuilding.Capacity = capacity;
									islands[0].Colony.Buildings[0] = productionBuilding;
									Console.WriteLine($"Capacity has been set to {capacity}");
									Console.WriteLine("Press any key to go back");
									Console.ReadKey();
									Manager();
									break;
								case 2:
									Console.Clear();
									productionBuilding = new ProductionBuilding();
									productionBuilding = (ProductionBuilding)islands[1].Colony.Buildings[0];
									Console.WriteLine("What capacity you want to set?");
									capacity = Convert.ToInt32(Console.ReadLine());
									productionBuilding.Capacity = capacity;
									islands[1].Colony.Buildings[0] = productionBuilding;
									Console.WriteLine($"Capacity has been set to {capacity}");
									Console.WriteLine("Press any key to go back");
									Console.ReadKey();
									Manager();
									break;
								case 3:
									Console.Clear();
									productionBuilding = new ProductionBuilding();
									productionBuilding = (ProductionBuilding)islands[2].Colony.Buildings[0];
									Console.WriteLine("What capacity you want to set?");
									capacity = Convert.ToInt32(Console.ReadLine());
									productionBuilding.Capacity = capacity;
									islands[2].Colony.Buildings[1] = productionBuilding;
									Console.WriteLine($"Capacity has been set to {capacity}");
									Console.WriteLine("Press any key to go back");
									Console.ReadKey();
									Manager();
									break;
								case 4:
									Console.Clear();
									productionBuilding = new ProductionBuilding();
									productionBuilding = (ProductionBuilding)islands[3].Colony.Buildings[0];
									Console.WriteLine("What capacity you want to set?");
									capacity = Convert.ToInt32(Console.ReadLine());
									productionBuilding.Capacity = capacity;
									islands[3].Colony.Buildings[1] = productionBuilding;
									Console.WriteLine($"Capacity has been set to {capacity}");
									Console.WriteLine("Press any key to go back");
									Console.ReadKey();
									Manager();
									break;
							}
							break;
						case 3:
							MainMenu(islands);
							break;

					} 
				}
			}

		}
		
		private static void writeInCenter(String text)
		{
			Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
			Console.WriteLine(text);
		}
	}
}
