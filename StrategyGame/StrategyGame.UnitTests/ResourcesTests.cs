using Xunit;
using System;
namespace StrategyGame.UnitTests
{
	public class ResourcesTests
	{
		[Theory]
		[InlineData(50, 40, 10)]
		[InlineData(-10, 0, 0)]
		[InlineData(110, 200, 11)]
		public void Subtract_decresesTotal(int x, int y, int z)
		{
			//arrange	
			var minuend = new Resources(100, 100, 100);
			var subtrahend = new Resources(x, y, z);
			var expected = new Resources(100 - x, 100 - y, 100 - z);
			//Act
			minuend.Subtract(subtrahend);

			//Assert 
			Assert.Equal(minuend.Food, expected.Food);
			Assert.Equal(minuend.Stone, expected.Stone);
			Assert.Equal(minuend.Wood, expected.Wood);
		}
		[Theory]
		[InlineData(50079, 40, 10)]
		[InlineData(-10, 1, 431)]
		[InlineData(110, 200, 11)]
		public void Move_ShouldNotMoveResources(int x, int y, int z)
		{

			//arrange	
			var from = new Resources(100, 100, 100);
			var to = new Resources(0, 0, 0);
			var amount = new Resources(x, y, z);
			var expected = new Resources(100 - x, 100 - y, 200 - z);
			//Act
			from.Move(to, amount);

			//Assert 
			Assert.NotEqual(from.Food, expected.Food);
			Assert.NotEqual(from.Stone, expected.Stone);
			Assert.NotEqual(from.Wood, expected.Wood);
			Assert.NotEqual(to.Food, x);
			Assert.NotEqual(to.Stone, y);
			Assert.NotEqual(to.Wood, z);
		}



	}
};