using Warehouse.ViewModels;
using Warehouse.vModel;
using Warehouse.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.Controllers
{
    public class SalesController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        // GET: Sales
        public ActionResult Index()
        {
            //var items = new Warehouse.ViewModels.Item()
            //{
            //    Id = 1,
            //    Price = 0,
            //    Quantity = 0,
            //    SalePrice = 0,
            //    TypeId = 1
            //};
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {

                var vm = new SaleViewModel()
                {
                    Items = new List<ViewModels.Item>()
                {
                    new ViewModels.Item()
                    {
                        Id = 1,
                Price = 0,
                Quantity = 0,
                SalePrice = 0,
                TypeId = 1
                    }
                }

                };

                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData)
        {
            var items = new List<vModel.Item>();
            var deliveries = new List<Operation>();
            var realItems = new List<vModel.Item>();
            for (int i = 0; i < ((formData.Count - 1) / 2); i++)
            {
                int.TryParse(formData["Items[" + i + "].Quantity"],out int qtty);
                items.Add(new vModel.Item()
                {
                    Name = formData["Items[" + i + "].Name"],
                    Quantity = qtty
                });
            }
            var date = DateTime.Now;
            var clientId = Session["Client"] != null ? Session["Client"].ToString() : null;
            int clienntId = 0;
            if (clientId != null)
                int.TryParse(clientId, out clienntId);

            foreach (var i in items)
            {
                //addEditDeleteService.InsertSale(new Sales()
                //{
                //    ItemId = int.Parse(i.Name),
                //    Date = date,
                //    Quantity = i.Quantity,
                //    ClientId = clienntId
                //});
                var item = addEditDeleteService.GetItem(int.Parse(i.Name));
                item.Quantity = i.Quantity;
                AddToCart(item);
                //item.Quantity -= i.Quantity;
                //addEditDeleteService.UpdateItem(item);
            }
            Session.Remove("Client");
            return RedirectToAction("Cart", "ShoppingCart");
        }

        public void AddToCart(vModel.Item item)
        {
            List<vModel.Item> cart = new List<vModel.Item>();
            if ((List<vModel.Item>)Session["cart"] != null)
                cart = (List<vModel.Item>)Session["cart"];

            cart.Add(item);
            Session["cart"] = cart;
            
        }

        [HttpPost]
        public ActionResult AddClient()
        {

            return PartialView("_Clients");
        }


        [HttpPost]
        public void AddClientToSession(Client client)
        {
            Session["Client"] = client.Id;

        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    var phones = new List<Phone>();
        //    phones.Add(new Phone()
        //    {
        //        Number = "2465452",
        //        Type = Phone.Types.Business
        //    });
        //    phones = new List<Phone>();
        //    phones.Add(new Phone()
        //    {
        //        Number = "2323",
        //        Type = Phone.Types.Cell
        //    });
        //    var vm = new EmployeeViewModel();
        //    vm.Name = "Gosho";
        //    vm.Phones.AddRange(phones);


        //    return View(vm);
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection formData)
        //{
        //    string name = formData["Name"];
        //    string phones0Type = formData["Phones[0].Type"];
        //    string phones1Number = formData["Phones[0].Number"];
        //    return RedirectToAction("Index");
        //}



    }
}