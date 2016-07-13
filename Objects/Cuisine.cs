using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestaurantList
{
  public class Cuisine
  {
    private int _id;
    private string _name;
    public Cuisine(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisines = new List<Cuisine> {};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisines;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int cuisineId = rdr.GetInt32(0);
        string cuisineName = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisineName, cuisineId);
        allCuisines.Add(newCuisine);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCuisines;
    }
  }
}
