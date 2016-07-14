using Nancy;

namespace RestaurantList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] =_=> View ["index.cshtml"];
      Get["/cuisinelist"] =_=> View["cuisinelist.cshtml", Cuisine.GetAll()];
      Get["/clearcuisines"] =_=> {
        Cuisine.DeleteAll();
        return View ["/cuisinelist", Cuisine.GetAll()];
      };
      Post ["/cuisine/created"] = _ => {
        Cuisine newCuisine = new Cuisine (Request.Form["cuisine-name"]);
        newCuisine.Save();
        return View ["cuisine_created.cshtml"];
      };
    }
  }
}
