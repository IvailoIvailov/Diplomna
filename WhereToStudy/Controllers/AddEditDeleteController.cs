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
    public class AddEditDeleteController : Controller
    {

        public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
        #region Type
        [HttpGet]
        public ActionResult AddType()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddType(Types type)
        {
            addEditDeleteService.InsertType(type);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                {
                    if (addEditDeleteService.GetItems().Any(m => m.TypeId == id))
                        ViewData["Message"] = "Съществуват артикули от този тип. Типът не може да бъде изтрит.";
                    else
                        addEditDeleteService.DeleteType(id);
                }

                return View(addEditDeleteService.GetTypes());
            }
        }
        
        [HttpGet]
        public ActionResult EditType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var type = addEditDeleteService.GetType(id);
                return View(type);
            }
        }

        [HttpPost]
        public ActionResult EditType(Types type)
        {
            addEditDeleteService.UpdateType(type);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Client
        
        [HttpGet]
        public ActionResult AddClient()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            addEditDeleteService.InsertClient(client);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteClient(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetOperationsByClientId(id).Any())
                        ViewData["Message"] = string.Format("Съществуват продажби към клиент {0}. Клиентът не може да бъде изтрит.", addEditDeleteService.GetClient(id).Name);
                    else
                        addEditDeleteService.DeleteClient(id);

                return View(addEditDeleteService.GetClients());
            }
        }
        
        [HttpGet]
        public ActionResult EditClient(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetClient(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            addEditDeleteService.UpdateClient(client);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Groups
        
        [HttpGet]
        public ActionResult AddGroup()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddGroup(Groups groups)
        {
            addEditDeleteService.InsertGroups(groups);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteGroup(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetItems().Any(m => m.GroupId == id))
                        ViewData["Message"] = string.Format("Съществуват артикули от група {0}. Артикулът не може да бъде изтрит.", addEditDeleteService.GetGroup(id).Name);
                    else
                        addEditDeleteService.DeleteGroup(id);

                return View(addEditDeleteService.GetGroups());
            }
        }
        
        [HttpGet]
        public ActionResult EditGroup(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetGroup(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditGroup(Groups groups)
        {
            addEditDeleteService.UpdateGroups(groups);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region OperationType
        
        [HttpGet]
        public ActionResult AddOperationType()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddOperationType(OperationType opt)
        {
            addEditDeleteService.InsertOperationType(opt);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult DeleteOperationType(int id = 0)
        {
                var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetOperations().Any(m => m.OperationTypeId == id))
                        ViewData["Message"] = string.Format("Съществуват операции от тип {0}. Типът не може да бъде изтрит.", addEditDeleteService.GetOperationType(id).Name);
                    else
                        addEditDeleteService.DeleteOperationType(id);

                return View(addEditDeleteService.GetOperationTypes());
            }
        }
        
        [HttpGet]
        public ActionResult EditOperationType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetOperationType(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditOperationType(OperationType opt)
        {
            addEditDeleteService.UpdateOperationType(opt);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region PaymentType

        [HttpGet]
        public ActionResult AddPaymentType()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddPaymentType(PaymentType opt)
        {
            addEditDeleteService.InsertPaymentType(opt);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DeletePaymentType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                //if (id != 0)
                //    if (addEditDeleteService.GetOperations().Any(m => m.PaymentTypeId == id))
                //        ViewData["Message"] = string.Format("Съществуват артикули от жанр {0}. Жанрът не може да бъде изтрит.", addEditDeleteService.GetOperationType(id).Name);
                //    else
                        addEditDeleteService.DeleteOperationType(id);
                addEditDeleteService.DeletePaymentType(id);
                return View(addEditDeleteService.GetPaymentTypes());
            }
        }

        [HttpGet]
        public ActionResult EditPaymentType(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var client = addEditDeleteService.GetPaymentType(id);
                return View(client);
            }
        }

        [HttpPost]
        public ActionResult EditPaymentType(PaymentType opt)
        {
            addEditDeleteService.UpdatePaymentType(opt);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Book

        [HttpGet]
        public ActionResult AddBook()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddBook(vModel.Item item)
        {
            if (item.Code == null)
                item.Code = string.Empty;
            addEditDeleteService.InsertItem(item);
            var itemId = addEditDeleteService.GetItemByName(item.Name).Id;
            addEditDeleteService.UploadImageToDB(Session["file"] as HttpPostedFileBase, itemId);
            return RedirectToAction("Index", "Availability");
        }
        
        [HttpGet]
        public ActionResult DeleteBook(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                if (id != 0)
                    if (addEditDeleteService.GetOperationDetails().Any(m => m.ItemId == id))
                        ViewData["Message"] = string.Format("Съществуват продажби/доставки на артикул {0}. Артикулът не може да бъде изтрит.", addEditDeleteService.GetItem(id).Name);
                    else
                        addEditDeleteService.DeleteItem(id);

                return View(addEditDeleteService.GetItems());
            }
        }
        
        [HttpGet]
        public ActionResult EditItem(int id = 0)
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "User");
            else
            {
                var book = addEditDeleteService.GetItem(id);
                return View(book);
            }
        }

        [HttpPost]
        public ActionResult EditItem(vModel.Item item)
        {
            addEditDeleteService.UpdateItem(item);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void UploadImage(IEnumerable<HttpPostedFileBase> files)
        {
            Session["file"] = files.FirstOrDefault(); ;
        }
    }
}