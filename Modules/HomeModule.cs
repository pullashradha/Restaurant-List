using Nancy;

namespace RestaurantList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] =_=> View ["index.cshtml"];
      Post ["/cuisine/created"] = _ => {
        Cuisine newCuisine = new Cuisine (Request.Form["cuisine-name"]);
        newCuisine.Save();
        return View ["cuisine_created.cshtml", newCuisine.GetName()];
      };
    }
  }
}
