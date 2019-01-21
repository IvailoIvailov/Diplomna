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
    public class ClientReportController : Controller
    {
        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();

        ClientsViewModel list = new ClientsViewModel();
        // GET: ClientReport
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                int clientId = 0;
                var sales = new List<vModel.Operation>();
                var items = new List<vModel.Item>();
                if (clientId == 0)
                    sales = addEditDeleteService.GetOperations().Where(o => o.OperationTypeId == 1).ToList();
                else
                    sales = addEditDeleteService.GetOperationsByClientId(clientId).Where(o=>o.OperationTypeId == 1).ToList();


                list.Client = addEditDeleteService.GetClient(clientId);
                foreach (var sale in sales)
                {
                    sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id);
                   foreach(var detail in sale.OperationDetails)
                    {
                        var item = addEditDeleteService.GetItem(detail.ItemId);
                        item.Quantity = detail.Quantity;
                        item.Date = sale.Date;
                        items.Add(item);

                    }
                }
                list.Items = items;

                return View(list);
            }
        }

        [HttpPost]
        public ViewResult Index(string sortOrder, int clientId = 0)
        {
            var items = new List<vModel.Item>();
            var sales = new List<vModel.Operation>();
            if (clientId == 0)
                sales = addEditDeleteService.GetOperations().Where(o => o.OperationTypeId == 1).ToList();
            else
                sales = addEditDeleteService.GetOperationsByClientId(clientId).Where(o => o.OperationTypeId == 1).ToList();
            foreach (var sale in sales)
            {
                sale.OperationDetails = addEditDeleteService.GetOperationDetail(sale.Id);
                foreach (var detail in sale.OperationDetails)
                {
                    var item = addEditDeleteService.GetItem(detail.ItemId);
                    item.Quantity = detail.Quantity;
                    item.Date = sale.Date;
                    items.Add(item);
                }
            }

            list.Items = items;
            list.Client = addEditDeleteService.GetClient(clientId);
            return View(list);
        }

        [HttpGet]
        public ActionResult ClientsReport()
        {
            var clients = addEditDeleteService.GetClients();
            return View(clients);
        }
    }
}