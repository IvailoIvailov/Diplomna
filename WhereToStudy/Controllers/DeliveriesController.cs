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
    public class DeliveriesController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        // GET: Deliveries
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var items = new Warehouse.ViewModels.Item()
                {
                    Id = 1,
                    Price = 0,
                    Quantity = 0,
                    SalePrice = 0,
                    TypeId = 1
                };
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

            var itemsToDelete = new List<vModel.Item>();
            var items2 = new List<vModel.Item>();
            var deliveries = new List<Operation>();
            var realItems = new List<vModel.Item>();
            for (int i = 0; i < ((formData.Count - 1) / 2); i++)
            {

                int.TryParse(formData["Items[" + i + "].Quantity"], out int qtty);
                items.Add(new vModel.Item()
                {
                    Name = formData["Items[" + i + "].Name"],
                    Quantity = qtty
                });
                itemsToDelete.Add(new vModel.Item()
                {
                    Name = formData["Items[" + i + "].Name"],
                    Quantity = qtty
                });
            }
            var date = DateTime.Now;
            items2 = items;

            for (int i = 0; i < items2.Count; i++)
            {
                var item = addEditDeleteService.GetItem(int.Parse(items2[i].Name));
                items2[i] = item;
            }

                addEditDeleteService.InsertOperation(new Operation()
            {
                Date = date,
                PartnerId = 0,
                Amount = items2.Sum(i => i.Quantity * i.Price),
                OperationTypeId = 2
                });

            var operationId = addEditDeleteService.GetOperations().LastOrDefault().Id;

            foreach (var i in itemsToDelete)
            {
                var item = addEditDeleteService.GetItem(int.Parse(i.Name));
                addEditDeleteService.InsertOperationDetail(new OperationDetail()
                {
                    ItemId = item.Id,
                    OperationId = operationId,
                    Quantity = i.Quantity,
                    SalePrice = item.SalePrice,
                    RowSum = item.SalePrice * i.Quantity
                });

                item.Quantity += i.Quantity;

                addEditDeleteService.UpdateItem(item);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var phones = new List<Phone>();
            phones.Add(new Phone()
            {
                Number = "2465452",
                Type = Phone.Types.Business
            });
            phones = new List<Phone>();
            phones.Add(new Phone()
            {
                Number = "2323",
                Type = Phone.Types.Cell
            });
            var vm = new EmployeeViewModel();
            vm.Name = "Gosho";
            vm.Phones.AddRange(phones);


            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            string name = formData["Name"];
            string phones0Type = formData["Phones[0].Type"];
            string phones1Number = formData["Phones[0].Number"];
            return RedirectToAction("Index");
        }


        public ActionResult ItemsDeliveries()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {          
                return View();
            }
        }

        [HttpPost]
        public ActionResult ItemsDeliveries(int id = 0)
        {
            var items = new List<vModel.Item>();
            var deliveries = new List<Operation>();
            var realItems = new List<vModel.Item>();
            //for (int i = 0; i < ((formData.Count - 1) / 2); i++)
            //{
            //    items.Add(new vModel.Item()
            //    {
            //        Name = formData["Items[" + i + "].Name"],
            //        Quantity = int.Parse(formData["Items[" + i + "].Quantity"])
            //    });
            //}
            var date = DateTime.Now;

            addEditDeleteService.InsertOperation(new Operation()
            {
                Date = date,
                PartnerId = 0,
                Amount = items.Sum(i => i.Quantity * i.Price),
                OperationTypeId = 2
            });

            foreach (var i in items)
            {
                // var quantity = items.FirstOrDefault(m => m.Name == i.Name).Quantity;
                
                var item = addEditDeleteService.GetItem(int.Parse(i.Name));
                item.Quantity += i.Quantity;

                addEditDeleteService.UpdateItem(item);
            }

            return RedirectToAction("Index");
        }

    }
}