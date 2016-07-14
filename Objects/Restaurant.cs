using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestaurantList
{
  public class Restaurant
  {
    private int _id;
    private string _name;
    private string _address;
    private string _phoneNumber;
    private string _description;
    private int _cuisineId;


    public Restaurant(string Name, string Address, string PhoneNumber, string Description, int CuisineId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _address = Address;
      _phoneNumber = PhoneNumber;
      _description = Description;
      _cuisineId = CuisineId;
    }
    public override bool Equals(System.Object otherRestaurant)
    {
      if(!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = (this.GetId() == newRestaurant.GetId());
        bool nameEquality = (this.GetName() == newRestaurant.GetName());
        bool addressEquality = (this.GetAddress() == newRestaurant.GetAddress());
        bool phoneNumberEquality = (this.GetPhoneNumber() == newRestaurant.GetPhoneNumber());
        bool descriptionEquality = (this.GetDescription() == newRestaurant.GetDescription());
        bool cuisineIdEquality =  (this.GetCuisineId() == newRestaurant.GetCuisineId());
        return (nameEquality && addressEquality && phoneNumberEquality && descriptionEquality && cuisineIdEquality && idEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetAddress()
    {
      return _address;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public string GetDescription()
    {
      return _description;
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }
    public void SetName(string NewName)
    {
      _name = NewName;
    }
    public void SetAddress(string NewAddress)
    {
      _address = NewAddress;
    }
    public void SetPhoneNumber(string NewPhoneNumber)
    {
      _phoneNumber = NewPhoneNumber;
    }
    public void SetDescription(string NewDescription)
    {
      _description = NewDescription;
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
        string restaurantAddress = rdr.GetString(2);
        string restaurantPhoneNumber = rdr.GetString(3);
        string restaurantDescription = rdr.GetString(4);
        int restaurantCuisine = rdr.GetInt32(5);

        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhoneNumber, restaurantDescription, restaurantCuisine, restaurantId);
        allRestaurants.Add(newRestaurant);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allRestaurants;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO restaurants (name, address, phone_number, description, cuisine_id) OUTPUT INSERTED.id VALUES (@RestaurantName, @RestaurantAddress, @RestaurantPhoneNumber, @RestaurantDescription, @CuisineId);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@RestaurantName";
      nameParameter.Value = this.GetName();
      SqlParameter addressParameter = new SqlParameter();
      addressParameter.ParameterName = "@RestaurantAddress";
      addressParameter.Value = this.GetAddress();
      SqlParameter phoneNumberParameter = new SqlParameter();
      phoneNumberParameter.ParameterName = "@RestaurantPhoneNumber";
      phoneNumberParameter.Value = this.GetPhoneNumber();
      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@RestaurantDescription";
      descriptionParameter.Value = this.GetDescription();
      SqlParameter cuisineIdParameter = new SqlParameter();
      cuisineIdParameter.ParameterName = "@CuisineId";
      cuisineIdParameter.Value = this.GetCuisineId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(addressParameter);
      cmd.Parameters.Add(phoneNumberParameter);
      cmd.Parameters.Add(descriptionParameter);
      cmd.Parameters.Add(cuisineIdParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static Restaurant Find(int QueryId)
    {
      List<Restaurant> resultList = new List<Restaurant> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants WHERE id = @QueryId;", conn);
      SqlParameter IdParameter = new SqlParameter();
      IdParameter.ParameterName = "@QueryId";
      IdParameter.Value = QueryId;
      cmd.Parameters.Add(IdParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string restaurantAddress = rdr.GetString(2);
        string restaurantPhoneNumber = rdr.GetString(3);
        string restaurantDescription = rdr.GetString(4);
        int restaurantCuisine = rdr.GetInt32(5);

        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhoneNumber, restaurantDescription, restaurantCuisine, restaurantId);
        resultList.Add(newRestaurant);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      Restaurant foundRestaurant = resultList[0];
      return foundRestaurant;
    }
    public static void DeleteOne(int QueryId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM restaurants WHERE id = @QueryId;", conn);
      SqlParameter IdParameter = new SqlParameter();
      IdParameter.ParameterName = "@QueryId";
      IdParameter.Value = QueryId;
      cmd.Parameters.Add(IdParameter);
      cmd.ExecuteNonQuery();
    }

    public static void DeleteByCuisine(int QueryId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM restaurants WHERE cuisine_id = @QueryId;", conn);
      SqlParameter IdParameter = new SqlParameter();
      IdParameter.ParameterName = "@QueryId";
      IdParameter.Value = QueryId;
      cmd.Parameters.Add(IdParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM restaurants;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
