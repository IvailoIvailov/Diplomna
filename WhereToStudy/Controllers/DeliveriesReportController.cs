using Warehouse.ViewModels;
using Warehouse.vModel;
using Warehouse.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhereToStudy.Controllers
{
    public class DeliveriesReportController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();

        DeliveriesViewModel list = new DeliveriesViewModel();

        // GET: DeliveriesReport
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var date = DateTime.Now;
                var deliveries = addEditDeleteService.GetOperationsByDate(date).Where(o => o.OperationTypeId == 2);
                List<Warehouse.vModel.Item> items = new List<Warehouse.vModel.Item>();

                if (deliveries == null || deliveries.Count() < 1)
                {
                    var del = new DeliveriesViewModel();
                    del.Date = date;
                    return View(del);
                }

                foreach (var del in deliveries)
                {
                    del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);
                    foreach (var detail in del.OperationDetails)
                    {
                        var item = addEditDeleteService.GetItem(detail.ItemId);
                        item.Quantity = detail.Quantity;
                        item.Date = del.Date;
                        items.Add(item);
                    }
                }

                list.Date = deliveries.FirstOrDefault().Date;
                list.Items = items;

                return View(list);
            }
        }

        [HttpPost]
        public ViewResult Index(string sortOrder, DateTime? searchDate = null)
        {
            if (!searchDate.HasValue)
                searchDate = DateTime.Now;

            var deliveries = addEditDeleteService.GetOperationsByDate(searchDate).Where(o => o.OperationTypeId == 2);
            List<Warehouse.vModel.Item> items = new List<Warehouse.vModel.Item>();

            list.Date = searchDate;
            if (deliveries.Count() < 1)
            {
                return View(list);
            }

            foreach (var del in deliveries)
            {
                del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);
                foreach (var detail in del.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    item.Quantity = detail.Quantity;
                    item.Date = del.Date;
                    items.Add(item);
                }
            }
            list.Items = items;

            return View(list);
        }

        public ActionResult IndexName()
        {
            var date = DateTime.Now;
            var deliveries = addEditDeleteService.GetOperationsByDate(date).Where(o => o.OperationTypeId == 2);
            List<Warehouse.vModel.Item> items = new List<Warehouse.vModel.Item>();

            foreach (var del in deliveries)
            {
                del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);
                foreach (var detail in del.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    item.Quantity = detail.Quantity;
                    item.Date = del.Date;
                    items.Add(item);
                }
            }

            list.Date = deliveries.FirstOrDefault().Date;
            list.Items = items.OrderBy(m => m.Name).ToList();

            var result = list;
            return View("Items", result);
        }

        public ActionResult IndexQuantity()
        {
            var date = DateTime.Now;
            var deliveries = addEditDeleteService.GetOperationsByDate(date).Where(o => o.OperationTypeId == 2);
            List<Warehouse.vModel.Item> items = new List<Warehouse.vModel.Item>();

            foreach (var del in deliveries)
            {
                del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);
                foreach (var detail in del.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    item.Quantity = detail.Quantity;
                    item.Date = del.Date;
                    items.Add(item);
                }
            }

            list.Date = deliveries.FirstOrDefault().Date;
            list.Items = items.OrderBy(m => m.Quantity).ToList();

            var result = list;
            return View("Items", result);
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
        public ViewResult ItemsDeliveries(string sortOrder, int id = 0)
        {
            var sortitem = addEditDeleteService.GetItem(id);

            var list = new DeliveriesViewModel();
            var operation = new List<Operation>();

            var deliveries = addEditDeleteService.GetOperations();
            //  var operations = addEditDeleteService.GetOperations().Where(o => o.OperationTypeId == 2);
            if (sortitem != null)
            {
                foreach (var del in deliveries)
                {
                    if (sortitem.Id != 0)
                        del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id).Where(p => p.ItemId == sortitem.Id).ToList();
                    else
                        del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);

                    operation.Add(del);
                }
            }


            list.Items = new List<Warehouse.vModel.Item>();
            list.Item = new Warehouse.ViewModels.Item() { Id = sortitem.Id, Price = sortitem.Price, Quantity = sortitem.Quantity, SalePrice = sortitem.SalePrice, TypeId = sortitem.TypeId };


            if (operation.Count() < 1)
            {
                return View(list);
            }

            foreach (var del in operation)
            {
                del.OperationDetails = addEditDeleteService.GetOperationDetail(del.Id);
                foreach (var detail in del.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    if (item.Id == sortitem.Id)
                    {
                        item.Quantity = detail.Quantity;
                        item.Date = del.Date;
                        list.Items.Add(item);
                    }
                }
            }

            return View(list);
        }
    }
}