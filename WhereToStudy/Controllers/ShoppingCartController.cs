using Warehouse.vModel;
using Warehouse.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhereToStudy.Controllers
{
    public class ShoppingCartController : Controller
    {
        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        public UserService userService = new UserService();
        // GET: ShoppingCart
        public ActionResult Cart()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                // Return the view
                return View();
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Id == id)
                    return i;
            return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");
        }
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                // cart.Add(new Item())
                Session["cart"] = cart;
            }
            else
            {

                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    // cart.Add(new Item())
                }
                else
                    cart[index].Quantity++;

                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ActionResult Update(FormCollection fc)
        {
            if (fc.Count > 0)
            {
                string[] quantities = fc.GetValues("quantity");
                List<Item> cart = (List<Item>)Session["cart"];
                for (int i = 0; i < cart.Count; i++)
                    cart[i].Quantity = Convert.ToInt32(quantities[i]);
                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ActionResult Checkout()
        {
            return View("Ckeckout");
        }

        public ActionResult saveOrder(Client client)
        {
            DateTime date = DateTime.Now;

            var items = (List<Item>)Session["cart"];

            addEditDeleteService.InsertOperation(new Operation()
            {
                Date = date,
                PartnerId = client.Id,
                Amount = items.Sum(i => i.Quantity * i.SalePrice),
                OperationTypeId = 1
            });
            var operationId = addEditDeleteService.GetOperations().LastOrDefault().Id;
            foreach (var i in items)
            {
                var item = addEditDeleteService.GetItemByName(i.Name);

                addEditDeleteService.InsertOperationDetail(new OperationDetail()
                {
                   ItemId = i.Id,
                   OperationId =operationId,
                   Quantity = i.Quantity,
                   SalePrice = i.SalePrice,
                   RowSum = i.SalePrice * i.Quantity
                });

                item.Quantity -= i.Quantity;

                addEditDeleteService.UpdateItem(item);
            }
            Session.Remove("cart");

            return RedirectToAction("Index","Home");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            List<Item> cart;
            if (Session["cart"] == null)
            {
                cart = new List<Item>();
                Session["cart"] = cart;
            }
            else
                cart = (List<Item>)Session["cart"];

            ViewData["CartCount"] = cart.Count();
            return PartialView("CartSummary");
        }
    }
}