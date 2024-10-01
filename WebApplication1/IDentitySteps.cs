/*
1-install Packages (sqlserver , tools,Microsoft.AspNetCore.Identity.EntityFrameworkCore)
2-Create class Application User inherit from IdentitiyUser 
3-change context inherit from DbContext to Identitiy dbContext
4- Migartion
5- create Account Contoller 
6-2 Action Resteration (Get - Post )
7- Create the view Model Register Class 
8-Create Register View
9-Register Service in Program Class 
10-Logout 
11- Add Autherize Filter in "Index" Action
12- Add Middelware Authentication
13- login Action
14- Create LoginView Model
15-Customize the Authenticate User (Layout)


public IActionResult TestClaims(){
    string name =User.Identity.Name;
    Claim IdClaim =User.Claims.FirstOrDefault(x=>x.Type==CliamType.NameIdentifier);
}   return Content("Claim to user id =" +IdClaim);

[AllowAnonymous] make all action [] expt this Action 
 */