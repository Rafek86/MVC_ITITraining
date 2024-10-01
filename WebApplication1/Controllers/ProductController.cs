using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //named Conventions
    public class ProductController : Controller
    {
        #region First Part
        ////Actions
        ////1- Can't be Private 
        ////2- Can't be Static
        ////3-Can't be Overload
        //public string ShowMsg() 
        //{
        //    return "Hello From First Action";
        //}

        //public ContentResult Showmsg()
        //{ 
        //    //Declare the Object 
        //    ContentResult result = new ContentResult();
        //    //Set data 
        //    result.Content = "Hello World";
        //    //Return Data
        //    return result;

        //}
        //public ViewResult ShowView()
        //{ 
        //    //Declare
        //    ViewResult result = new ViewResult();

        //    //Set
        //    result.ViewName = "View1";
        //    //return
        //    return result;

        //}
        //public JsonResult ShowJson() { 

        //JsonResult result =new JsonResult(new  {id =1,name ="Ahmed" });
        //return result;
        //}

        ////Product/Details/1 //With Action Parameterwiht name Only id
        ////Product/Details?id=1 with Any Action Parameter

        ////if Two Or more Parameters 
        ////Product/Details/1?Param2=value //With Action Parameterwiht name Only id
        ////Product/Details?id=1&Param2=value with Any Action Parameter
        //public IActionResult Details(int id) {
        //    if (id % 2 == 0)
        //    {
        //        ////Declare the Object 
        //        //ContentResult result = new ContentResult();
        //        ////Set data 
        //        //result.Content = "Hello World";
        //        ////Return Data
        //        //return result;

        //        return Content("Hello");
        //    }
        //    else {

        //      return View("View1");
        //    }
        //}
        ////Type Action Can Return
        //    //Content => String =>ContentResult  
        //    //View => HTML => ViewResult
        //    //Json  => JsonResult 
        //    //not Found => NotFound Result
        //    // File 
        #endregion
        ProductSampleData sampleData = new ProductSampleData();

        //Show Details By Id
        public IActionResult index() {

            List<Product> products = sampleData.GetAll();
            return View("ShowAll",products);
        }
        public IActionResult Details(int Id) { 
        //Ask Model
        //Send To View
         Product Productmodel=   sampleData.GetProductById(Id);
            return View("ProductDetails",Productmodel);
        }
    }
}
