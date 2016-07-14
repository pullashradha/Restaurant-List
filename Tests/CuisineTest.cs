using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace RestaurantList
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_list_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void CuisineTest_EmptyDatabase_0()
    {
      int numberOfCuisines = Cuisine.GetAll().Count;
      Assert.Equal(0, numberOfCuisines);
    }
    [Fact]
    public void CuisineTest_EqualIfNamesMatch_true()
    {
      Cuisine newCuisine1 = new Cuisine("Italian");
      Cuisine newCuisine2 = new Cuisine("Italian");
      Assert.Equal(newCuisine1, newCuisine2);
    }
    [Fact]
    public void CuisineTest_Save_SaveAllCuisinesToDatabase()
    {
      Cuisine newCuisine = new Cuisine("Italian");
      newCuisine.Save();
      List<Cuisine> resultList = Cuisine.GetAll();
      Assert.Equal(newCuisine, resultList[0]);
    }
    [Fact]
    public void CuisineTest_Save_UpdatesCuisineId()
    {
      Cuisine newCuisine = new Cuisine("Italian");
      newCuisine.Save();
      int sqlId = Cuisine.GetAll()[0].GetId();
      int nonDbId = newCuisine.GetId();
      Assert.Equal(nonDbId, sqlId);
    }
    [Fact]
    public void CuisineTest_Find_ReturnsCorrectCuisine()
    {
      Cuisine newCuisine = new Cuisine("Italian");
      newCuisine.Save();
      int newCuisineId = newCuisine.GetId();
      Cuisine foundCuisine = Cuisine.Find(newCuisineId);
      Assert.Equal(foundCuisine, newCuisine);
    }
    [Fact]
    public void CuisineTest_GetRestaurants_RetrievesAllRestaurantsInCuisineCategory()
    {
      Cuisine newCuisine = new Cuisine("Italian");
      newCuisine.Save();
      Restaurant newRestaurant1 = new Restaurant("Olive Garden", "1010 SW Washington St", "555-555-5555", "It's food", newCuisine.GetId());
      newRestaurant1.Save();
      Restaurant newRestaurant2 = new Restaurant("Buffalo Wild Wings", "333 NE Kestrel Ave", "555-555-5555", "Definitely not Italian food", newCuisine.GetId());
      newRestaurant2.Save();
      List<Restaurant> testRestaurantList = new List<Restaurant> {newRestaurant1, newRestaurant2};
      List<Restaurant> resultRestaurantList = newCuisine.GetRestaurants();
      Assert.Equal(testRestaurantList, resultRestaurantList);
    }
    [Fact]
    public void CuisineTest_DeleteOne_DeletesOneCuisine()
    {
      Cuisine newCuisine1 = new Cuisine("Italian");
      Cuisine newCuisine2 = new Cuisine("Italian");
      newCuisine1.Save();
      newCuisine2.Save();
      int newCuisineId = newCuisine1.GetId();
      Cuisine.DeleteOne(newCuisineId);
      Assert.Equal(1, Cuisine.GetAll().Count);
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
      Cuisine.DeleteAll();
    }
  }
}
