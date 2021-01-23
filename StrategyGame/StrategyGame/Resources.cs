using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
	public class Resources
	{
		public int Food;
		public int Wood;
		public int Stone;

		public Resources()
		{

		}
		public Resources(int food, int wood, int stone)
		{
			Food = food;
			Wood = wood;
			Stone = stone;
		}
		public void ShowResources()
		{
			Console.WriteLine(
				"Food: "+ Food+ 
				", Wood: "+ Wood+ 
				", Stone: "+Stone);

		}
		public void Subtract (Resources subtrahend)
		{
			this.Food -= subtrahend.Food;
			this.Wood -= subtrahend.Wood;
			this.Stone -= subtrahend.Stone;
		}

		public void increament(decimal multiplier)
		{
			Food = (int)(Food * multiplier);
			Wood = (int)(Wood * multiplier);
			Stone = (int)(Stone * multiplier);
		}
		public void Move(Resources To, Resources Amount)
		{
			if (this.Food >= Amount.Food && this.Wood >= Amount.Wood && this.Stone >= Amount.Stone)
			{
				To.Food += Amount.Food;
				this.Food -= Amount.Food;
				To.Stone += Amount.Stone;
				this.Stone -= Amount.Stone;
				To.Wood += Amount.Wood;
				this.Wood -= Amount.Wood;
			}
			else
			{
				var color = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("you don't have enough resources in your Warehouse!\nMaximum amount you can transfer is: ");
				this.ShowResources();
				Console.ForegroundColor = color;
			}

		}
	}
}
