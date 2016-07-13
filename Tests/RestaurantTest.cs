using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace RestaurantList
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_list_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void RestaurantTest_EmptyDatabase_0()
    {
      int numberOfRestaurants = Restaurant.GetAll().Count;
      Assert.Equal(0, numberOfRestaurants);
    }
    [Fact]
    public void RestaurantTest_EqualIfNamesMatch_true()
    {
      Restaurant newRestaurant1 = new Restaurant("Hotlips Pizza", "Oak Street", "555-555-pizza","they have pizza there", 1);
      Restaurant newRestaurant2 = new Restaurant("Hotlips Pizza", "Oak Street", "555-555-pizza","they have pizza there", 1);
      Assert.Equal(newRestaurant1, newRestaurant2);
    }
    [Fact]
    public void RestaurantTest_Save_SavesRestaurantsToDatabase()
    {
      Restaurant newRestaurant = new Restaurant("Hotlips Pizza", "Oak Street", "555-555-pizza","they have pizza there", 1);
      newRestaurant.Save();
      List<Restaurant> resultList = Restaurant.GetAll();
      Assert.Equal(newRestaurant, resultList[0]);
    }
    [Fact]
    public void RestaurantTest_Save_UpdatesRestaurantId()
    {
      Restaurant newRestaurant = new Restaurant("Hotlips Pizza", "Oak Street", "555-555-pizza","they have pizza there", 1);
      newRestaurant.Save();
      int sqlId = Restaurant.GetAll()[0].GetId();
      int nonDbId = newRestaurant.GetId();
      Assert.Equal(nonDbId, sqlId);
    }
    [Fact]
    public void RestaurantTest_Find_ReturnsCorrectRestaurant()
    {
      Restaurant newRestaurant = new Restaurant("Hotlips Pizza", "Oak Street", "555-555-pizza","they have pizza there", 1);
      newRestaurant.Save();
      int newRestaurantId = newRestaurant.GetId();
      Restaurant foundRestaurant = Restaurant.Find(newRestaurantId);
      Assert.Equal(foundRestaurant, newRestaurant);
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
  }
}
