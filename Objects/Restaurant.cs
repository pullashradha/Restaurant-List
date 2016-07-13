using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestaurantList
{
  public class Restaurant
  {
    private int _id;
    private string _name;
    private int _cuisineId;

    public Restaurant(string Name, int CuisineId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _cuisineId = CuisineId;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetCuisineId()
    {
      return _cuisineId;
    }

    public void SetName(string NewName)
    {
      _name = NewName;
    }

    public void SetCuisine(int NewCuisine)
    {
      _cuisineId = NewCuisine;
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant> {};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants;", conn);
      rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        int restaurantCuisine = rdr.GetInt32(2);

        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantCuisine, restaurantId);
        allRestaurants.Add(newRestaurant);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allRestaurants;
    }
  }
}
