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
    public class ItemsReportController : Controller
    {
        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        // GET: ItemsReport
        public ActionResult Items()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var vm = new SaleReportViewModel();
                var date = DateTime.Now;
                var sales = addEditDeleteService.GetOperationsByDate(date).Where(p => p.OperationTypeId == 1).ToList();
                vm.Items = new List<Warehouse.vModel.Item>();

                foreach (var sale in sales)
                {
                    sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id);
                    foreach (var detail in sale.OperationDetails)
                    {
                        var item = addEditDeleteService.GetItem(detail.ItemId);
                        item.Quantity = detail.Quantity;
                        item.Date = sale.Date;
                        vm.Items.Add(item);
                    }
                }
                vm.Date = date;
                return View(vm);
            }
        }

        [HttpPost]
        public ViewResult Items(string sortOrder, DateTime? searchDate = null)
        {
            if (!searchDate.HasValue)
                searchDate = DateTime.Now;

            var vm = new SaleReportViewModel();
            var sales = addEditDeleteService.GetOperationsByDate(searchDate).Where(p => p.OperationTypeId == 1).ToList();
            vm.Items = new List<Warehouse.vModel.Item>();

            vm.Date = searchDate;
            if (sales.Count < 1)
            {
                return View(vm);
            }

            foreach (var sale in sales)
            {
                sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id);
                foreach (var detail in sale.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    item.Quantity = detail.Quantity;
                    item.Date = sale.Date;
                    vm.Items.Add(item);
                }
            }
            vm.Date = searchDate;
            return View(vm);
        }

        public ActionResult IndexName()
        {
            var items = addEditDeleteService.GetItems();
            return View("Items", items.OrderBy(m => m.Name));
        }

        public ActionResult IndexQuantity()
        {
            var items = addEditDeleteService.GetItems();
            return View("Items", items.OrderBy(m => m.Quantity));
        }



        public ActionResult ItemsSaleReport()
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
        public ViewResult ItemsSaleReport(string sortOrder, int id = 0)
        {
            var sortItem = addEditDeleteService.GetItem(id);

            var vm = new SaleReportViewModel();
            var operation = new List<Operation>();


            var sales = addEditDeleteService.GetOperations();
            if (sortItem != null)
            {

                foreach (var sale in sales)
                {
                    if (sortItem.Id != 0)
                        sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id).Where(p => p.ItemId == sortItem.Id).ToList();
                    else
                        sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id);
                    operation.Add(sale);
                }

                vm.Items = new List<Warehouse.vModel.Item>();

                vm.Item = new Warehouse.ViewModels.Item() { Id = sortItem.Id, Price = sortItem.Price, Quantity = sortItem.Quantity, SalePrice = sortItem.SalePrice, TypeId = sortItem.TypeId };
                if (sales.Count() < 1)
                {
                    return View(vm);
                }

                //foreach (var sale in sales)
                //{
                //    var item = addEditDeleteService.GetItem(sale.ItemId);
                //    item.Quantity = sale.Quantity;
                //    item.Date = sale.Date;
                //    vm.Items.Add(item);
                //}
            }

            foreach (var sale in operation)
            {
                foreach (var det in sale.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(det.ItemId);
                    item.Quantity = det.Quantity;
                    item.Date = sale.Date;
                    vm.Items.Add(item);
                }
            }

            return View(vm);
        }
    }
}