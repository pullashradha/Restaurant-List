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
      Restaurant newRestaurant1 = new Restaurant("Hotlips Pizza", 1);
      Restaurant newRestaurant2 = new Restaurant("Hotlips Pizza", 1);
      Assert.Equal(newRestaurant1, newRestaurant2);
    }
    [Fact]
    public void RestaurantTest_Save_SavesRestaurantToDatabase()
    {
      Restaurant newRestaurant = new Restaurant("Hotlips Pizza",1);
      newRestaurant.Save();
      List<Restaurant> resultList = Restaurant.GetAll();
      Assert.Equal(newRestaurant, resultList[0]);
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
  }
}
