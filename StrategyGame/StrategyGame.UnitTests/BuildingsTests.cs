using Moq;
using Xunit;

namespace StrategyGame.UnitTests
{
	public class BuildingsTests 
	{
		[Fact]
		public void Build_BuildingShouldbeFlaggedActive()
		{
			//arrange	
			bool expected = true;
			var building = new CivilianBuilding(new Warehouse(new Resources(100, 100, 100)));
			
			//Act
			building.Build();

			//Assert 
			Assert.Equal(expected, building.Active);
		}
		[Fact]
		public void Build_BuildingShouldbeFlaggedInactive()
		{
			//arrange	
			bool expected = false;
			var building = new CivilianBuilding(new Warehouse(new Resources(1, 5, 0)));

			//Act
			building.Build();

			//Assert 
			Assert.Equal(expected, building.Active);
		}
		[Fact]
		public void Upgrade_ShouldIncreaseBuildingLevel()
		{
			//arrange	
			var building = new CivilianBuilding(new Warehouse(new Resources(100, 100, 100)));
			int expected = building.Level+1;
			//Act
			building.Upgrade();

			//Assert 
			Assert.Equal(expected, building.Level);
		}
		[Fact]
		public void Upgrade_ShouldNOTIncreaseBuildingLevel()
		{
			//arrange	

			var building = new CivilianBuilding(new Warehouse(new Resources(0, 0, 0)));
			int expected = building.Level;
			//Act

			building.Upgrade();

			//Assert 
			Assert.Equal(expected, building.Level);
		}
		[Fact]
		public void Train_ShouldInremeantUnitNumber()
		{
			//arrange	

			var building = new CivilianBuilding(new Warehouse(new Resources(100, 100, 100)));
			int expected = building.workers.Count;
			//Act

			building.train(5);

			//Assert 
			Assert.NotEqual(expected, building.workers.Count);
		}
		[Fact]
		public void Train_ShouldNotInremeantUnitNumber()
		{
			//arrange	
			var warehouse = new Warehouse(new Resources(0, 0, 0));
			var building = new CivilianBuilding(warehouse);
			int expected = building.workers.Count;
			//Act

			building.train(5); //no food case

			warehouse.Add(new Resources(1000, 0, 0));

			building.train(20); //no
								//
								//case 

			//Assert 
			Assert.Equal(expected, building.workers.Count);
		}
	}
}