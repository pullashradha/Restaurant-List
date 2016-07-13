using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace RestaurantList
{
  public class CuisineTest
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_list_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_EmptyDatabase_true()
    {
      Cuisine newCuisine = new Cuisine ();
      int numberOfCuisines = newCuisine.GetAll().Count;
      Assert.Equal(0, numberOfCuisines);
    }
  }
}
