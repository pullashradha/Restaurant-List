using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestaurantList
{
  public class Review
  {
    private int _id;
    private string _userName;
    private string _reviewText;
    private int _restaurantId;
    public Review(string UserName, string ReviewText, int RestaurantId, int Id = 0)
    {
      _id = Id;
      _userName = UserName;
      _reviewText = ReviewText;
      _restaurantId = RestaurantId;
    }

    public override bool Equals(System.Object otherReview)
    {
      if(!(otherReview is Review))
      {
        return false;
      }
      else
      {
        Review newReview = (Review) otherReview;
        bool idEquality = (this.GetId() == newReview.GetId());
        bool userNameEquality = (this.GetUserName() == newReview.GetUserName());
        bool reviewTextEquality = (this.GetReviewText() == newReview.GetReviewText());
        bool restaurantIdEquality = (this.GetRestaurantId() == newReview.GetRestaurantId());
        return (idEquality && userNameEquality && reviewTextEquality && restaurantIdEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetUserName()
    {
      return _userName;
    }
    public void SetUserName(string NewName)
    {
      _userName = NewName;
    }
    public string GetReviewText()
    {
      return _reviewText;
    }
    public void SetReviewText(string NewText)
    {
      _reviewText = NewText;
    }
    public int GetRestaurantId()
    {
      return _restaurantId;
    }
    public void SetRestaurantId(int NewRestaurantId)
    {
      _restaurantId = NewRestaurantId;
    }
    public static List<Review> GetAll()
    {
      List<Review> allReviews = new List<Review> {};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM reviews;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int reviewId = rdr.GetInt32(0);
        string reviewUserName = rdr.GetString(1);
        string reviewText = rdr.GetString(2);
        int restaurantId = rdr.GetInt32(3);
        Review newReview = new Review(reviewUserName, reviewText, restaurantId, reviewId);
        allReviews.Add(newReview);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allReviews;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO reviews (user_name, review_text, restaurant_id) OUTPUT INSERTED.id VALUES (@UserName, @ReviewText, @RestaurantId);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@UserName";
      nameParameter.Value = this.GetUserName();
      cmd.Parameters.Add(nameParameter);
      SqlParameter textParameter = new SqlParameter();
      textParameter.ParameterName = "@ReviewText";
      textParameter.Value = this.GetReviewText();
      cmd.Parameters.Add(textParameter);
      SqlParameter restaurantIdParameter = new SqlParameter();
      restaurantIdParameter.ParameterName = "@RestaurantId";
      restaurantIdParameter.Value = this.GetRestaurantId();
      cmd.Parameters.Add(restaurantIdParameter);
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
    public static Review Find(int QueryId)
    {
      List<Review> resultList = new List<Review> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand("SELECT * FROM reviews WHERE id = @QueryId;", conn);
      SqlParameter IdParameter = new SqlParameter();
      IdParameter.ParameterName = "@QueryId";
      IdParameter.Value = QueryId;
      cmd.Parameters.Add(IdParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int returnId = rdr.GetInt32(0);
        string returnName = rdr.GetString(1);
        string returnReviewText = rdr.GetString(2);
        int returnRestaurantId = rdr.GetInt32(3);
        Review newReview = new Review(returnName, returnReviewText, returnRestaurantId, returnId);
        resultList.Add(newReview);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      // Review foundReview = ;
      return resultList[0];
    }
    public static void DeleteOne(int QueryId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM reviews where id = @QueryId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@QueryId";
      idParameter.Value = QueryId;
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM reviews;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
