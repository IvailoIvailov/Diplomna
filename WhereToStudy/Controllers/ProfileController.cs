using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.vModel;
using Warehouse.vServices;

namespace Warehouse.Controllers
{
    public class ProfileController : Controller
    {
        private UserService userService = new UserService();

        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var model = userService.GetUser(user);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            user.Id = userService.GetUser(user).Id;
            userService.UpdateUser(user);
            return RedirectToAction("Index", "Profile");
        }
    }
}