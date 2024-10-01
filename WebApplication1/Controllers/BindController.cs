using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BindController : Controller
    {
        //MOdel Binding Map Action Parameter with Request Data(form Data a, Query String , Route data)
        //Bind Premitive type
        //Bind/testPr/id?name="rafek
        //Bind/testPr?id=1&name=rafek
        //if you ignore a parameter in Url it will take the Default value for it 
        //if you add a parameter doesn't Exist in this Action هيقولك زيادة الخير خيرين
        //in case Array => ?arrName=value1&arrName=value2 (value1 in index[0] and value2 in index[1]) 
        public IActionResult testPr(int id, string name)
        {
            return Content($"name={name}, id={id}");
        }
        //Bind/testDic?Phones[key]=123&Phones[key]456
        public IActionResult testDic(Dictionary<string, int> Phones, string name)
        {
            return Content($"name is {name}");
        }

        //Bind/testComplex?name=rafek&id=555&managername=samy
        public IActionResult testComplex(Department dept) {
            //will seach for all Properties Of the Object
            return Content($"name is {dept.Name}");
        } 
        public IActionResult CustomTestComplex([Bind(include:"Id,Name")]Department dept) {
            //will seach for all Properties Of the Object
            return Content($"name is {dept.Name}");
        }
    }
}
