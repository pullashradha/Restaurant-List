using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace RestaurantList
{
  public class ReviewTest : IDisposable
  {
    public ReviewTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_list_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void ReviewTest_EmptyDatabase_0()
    {
      int numberOfReviews = Review.GetAll().Count;
      Assert.Equal(0, numberOfReviews);
    }
    [Fact]
    public void ReviewTest_EqualIfNamesMatch_true()
    {
      Review newReview1 = new Review("ExampleName", "I love this restaurant!", 1);
      Review newReview2 = new Review("ExampleName", "I love this restaurant!", 1);
      Assert.Equal(newReview1, newReview2);
    }
    [Fact]
    public void ReviewTest_Save_SaveAllReviewsToDatabase()
    {
      Review newReview = new Review("ExampleName", "I love this restaurant!", 1);
      newReview.Save();
      List<Review> resultList = Review.GetAll();
      Assert.Equal(newReview, resultList[0]);
    }
    [Fact]
    public void ReviewTest_Save_UpdatesReviewId()
    {
      Review newReview = new Review("ExampleName", "I love this restaurant!", 1);
      newReview.Save();
      int sqlId = Review.GetAll()[0].GetId();
      int nonDbId = newReview.GetId();
      Assert.Equal(nonDbId, sqlId);
    }
    [Fact]
    public void ReviewTest_Find_ReturnsCorrectReview()
    {
      Review newReview = new Review("ExampleName", "I love this restaurant!", 1);
      newReview.Save();
      int newReviewId = newReview.GetId();
      Review foundReview = Review.Find(newReviewId);
      Assert.Equal(foundReview, newReview);
    }
    [Fact]
    public void ReviewTest_DeleteOne_DeletesOneReview()
    {
      Review newReview1 = new Review("ExampleName", "I love this restaurant!", 1);
      Review newReview2 = new Review("ExampleName", "I love this restaurant!", 1);
      newReview1.Save();
      newReview2.Save();
      int newReviewId = newReview1.GetId();
      Review.DeleteOne(newReviewId);
      Assert.Equal(1, Review.GetAll().Count);
    }
    public void Dispose()
    {
      Review.DeleteAll();
    }
  }
}
