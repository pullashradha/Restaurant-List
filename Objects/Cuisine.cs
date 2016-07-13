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
    
  }
}
