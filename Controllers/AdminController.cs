using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminAPI.Models;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public static List<Admin> admins = Admin.GetAllAdmins();
        [HttpGet]
        [Route("getfromdatabase")]
        public IActionResult getalladmins()
        {

            return Ok(admins);
        }

        [HttpPost]
        [Route("inserttodatabase")]

        public IActionResult insertallrecords(Admin A)
        {
            Admin.insertAdminUsers(A);
            return Ok();

        }

       [HttpGet]
       [Route("Checking LoginCredentials")]
       public ActionResult<bool> Login(string Admin_email, string Admin_password)
        {
            if(Admin.Login(Admin_email, Admin_password))
            { 
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }





    }
}
