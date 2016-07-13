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

    public void Dispose()
    {
      // Restaurant.DeleteAll();
    }
  }
}
