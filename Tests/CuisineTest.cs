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
    public void Test_EmptyDatabase_0()
    {
      int numberOfCuisines = Cuisine.GetAll().Count;
      Assert.Equal(0, numberOfCuisines);
    }

    [Fact]
    public void Cuisine_EqualIfNamesMatch_true()
    {
      Cuisine newCuisine1 = new Cuisine("Italian");
      Cuisine newCuisine2 = new Cuisine("Italian");
      Assert.Equal(newCuisine1, newCuisine2);
    }
  }
}
