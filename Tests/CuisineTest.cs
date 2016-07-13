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
      List<Cuisine> newCuisineList = new List<Cuisine> {newCuisine};
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
    public void Dispose()
    {
      Cuisine.DeleteAll();
    }
  }
}
