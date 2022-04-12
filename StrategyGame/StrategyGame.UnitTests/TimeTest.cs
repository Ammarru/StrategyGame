using Xunit;

namespace StrategyGame.UnitTests
{
	public class TimeTest
	{
		[Fact]
		public void SkipDay_ShouldIncreaseIslandResources()
		{

			//Arrange
			var island = new Island("Island", new Colony
				(new Warehouse(new Resources(1000, 1000, 1000)), "name")
				, new Nomad(5, new Resources(1000, 1000, 1000)));
			var expected = new Resources(100,100,100);
			//Act
			island.SkipDay();

			//Assert
			Assert.NotEqual(expected.Food, island.Resources.Food);
			Assert.NotEqual(expected.Stone, island.Resources.Stone);
			Assert.NotEqual(expected.Wood, island.Resources.Wood);
		}

		[Fact]
		public void SkipDay_ShouldIncreaseBuildingResources()
		{

			//Arrange
			var warehouse = new Warehouse(new Resources(100, 100, 100));
			var building = new ProductionBuilding(warehouse);
			var expected = new Resources(100, 100, 100);
			//Act
			building.SkipDay();

			//Assert
			Assert.NotEqual(expected.Food, warehouse.Storage.Food);
			Assert.NotEqual(expected.Stone, warehouse.Storage.Stone);
			Assert.NotEqual(expected.Wood, warehouse.Storage.Wood);
		}
	}
}
