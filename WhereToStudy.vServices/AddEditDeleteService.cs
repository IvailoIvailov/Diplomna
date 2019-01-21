using Warehouse.vModel;
using Warehouse.vRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Warehouse.vServices
{
    public class AddEditDeleteService
    {
        public AddEditDeleteRepository addEditDeleteRepository;

        public AddEditDeleteService()
        {
            addEditDeleteRepository = new AddEditDeleteRepository();
        }

        #region Type
        public Types GetType(int id)
        {
            return addEditDeleteRepository.GetType(id);
        }

        public List<Types> GetTypes()
        {
            return addEditDeleteRepository.GetTypes();
        }

        public Types InsertType(Types type)
        {
            return addEditDeleteRepository.InsertType(type);
        }
        public Types UpdateType(Types type)
        {
            return addEditDeleteRepository.UpdateType(type);
        }

        public Types DeleteType(int id)
        {
            return addEditDeleteRepository.DeleteType(id);
        }
        #endregion

        #region Item
        public Item GetItem(int id)
        {
            return addEditDeleteRepository.GetItem(id);
        }

        public List<Item> GetItems()
        {
            return addEditDeleteRepository.GetItems();
        }

        public Image GetItemImage(int itemId)
        {
            return addEditDeleteRepository.GetItemImage(itemId);
        }
        

        public Item InsertItem(Item item)
        {
            return addEditDeleteRepository.InsertItem(item);
        }
        public Item UpdateItem(Item item)
        {
            return addEditDeleteRepository.UpdateItem(item);
        }

        public Item DeleteItem(int id)
        {
            return addEditDeleteRepository.DeleteItem(id);
        }

        public Item GetItemByName(string name)
        {
            return addEditDeleteRepository.GetItemByName(name);
        }

        public List<Item> GetItemsByType(int typeId)
        {
            return addEditDeleteRepository.GetItemsByType(typeId);
        }        
        public List<Operation> GetOperationsByClientId(int clientId)
        {
            return addEditDeleteRepository.GetOperationByCientId(clientId);
        }
        public List<Operation> GetOperationsByDate(DateTime date)
        {
            return addEditDeleteRepository.GetOperationsByDate(date);
        }

        #endregion

        #region Client
        public Client GetClient(int id)
        {
            return addEditDeleteRepository.GetClient(id);
        }

        public List<Client> GetClients()
        {
            return addEditDeleteRepository.GetClients();
        }

        public Client InsertClient(Client client)
        {
            return addEditDeleteRepository.InsertClient(client);
        }
        public Client UpdateClient(Client client)
        {
            return addEditDeleteRepository.UpdateClient(client);
        }

        public Client DeleteClient(int id)
        {
            return addEditDeleteRepository.DeleteClient(id);
        }
        #endregion

        #region PaymentType
        public PaymentType GetPaymentType(int id)
        {
            return addEditDeleteRepository.GetPaymentType(id);
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return addEditDeleteRepository.GetPaymentTypes();
        }

        public PaymentType InsertPaymentType(PaymentType pt)
        {
            return addEditDeleteRepository.InsertPaymentType(pt);
        }
        public PaymentType UpdatePaymentType(PaymentType pt)
        {
            return addEditDeleteRepository.UpdatePaymentType(pt);
        }

        public PaymentType DeletePaymentType(int id)
        {
            return addEditDeleteRepository.DeletePaymentType(id);
        }
        #endregion

        #region Groups
        public Groups GetGroup(int id)
        {
            return addEditDeleteRepository.GetGroup(id);
        }

        public List<Groups> GetGroups()
        {
            return addEditDeleteRepository.GetGroups();
        }

        public Groups InsertGroups(Groups group)
        {
            return addEditDeleteRepository.InsertGroup(group);
        }
        public Groups UpdateGroups(Groups gr)
        {
            return addEditDeleteRepository.UpdateGroups(gr);
        }

        public Groups DeleteGroup(int id)
        {
            return addEditDeleteRepository.DeleteGroups(id);
        }
        #endregion

        #region OperationType
        public OperationType GetOperationType(int id)
        {
            return addEditDeleteRepository.GetOperationType(id);
        }

        public List<OperationType> GetOperationTypes()
        {
            return addEditDeleteRepository.GetOperationTypes();
        }

        public OperationType InsertOperationType(OperationType group)
        {
            return addEditDeleteRepository.InsertOperationType(group);
        }
        public OperationType UpdateOperationType(OperationType gr)
        {
            return addEditDeleteRepository.UpdateOperationType(gr);
        }

        public OperationType DeleteOperationType(int id)
        {
            return addEditDeleteRepository.DeleteOperationType(id);
        }
        #endregion

        #region Operations
        public Operation GetOperation(int id)
        {
            return addEditDeleteRepository.GetOperation(id);
        }

        public List<Operation> GetOperations()
        {
            return addEditDeleteRepository.GetOperations();
        }

        public List<Operation> GetOperationsByDate(DateTime? date)
        {
            return addEditDeleteRepository.GetOperationsByDate(date);
        }

        public Operation InsertOperation(Operation operation)
        {
            return addEditDeleteRepository.InsertOperation(operation);
        }
        public Operation UpdateOperation(Operation operation)
        {
            return addEditDeleteRepository.UpdateOperation(operation);
        }

        public Operation DeleteOperation(int id)
        {
            return addEditDeleteRepository.DeleteOperation(id);
        }
        #endregion

        #region OperationDetails
        public List<OperationDetail> GetOperationDetail(int id)
        {
            return addEditDeleteRepository.GetOperationDetail(id);
        }

        public List<OperationDetail> GetOperationDetails()
        {
            return addEditDeleteRepository.GetOperationDetails();
        }


        public OperationDetail InsertOperationDetail(OperationDetail operation)
        {
            return addEditDeleteRepository.InsertOperationDetail(operation);
        }

        public OperationDetail DeleteOperationDetail(int id)
        {
            return addEditDeleteRepository.DeleteOperationDetail(id);
        }
        #endregion

        public void UploadImageToDB(HttpPostedFileBase file, int itemId)
        {
            Image img = new Image();
            img.ContentType = file.ContentType;
            img.Name = file.FileName;
            img.Data = ConvertToBytes(file);
            img.ItemId = itemId;
            addEditDeleteRepository.InsertImage(img);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(Image.InputStream);
            imageBytes = reader.ReadBytes((int)Image.ContentLength);
            return imageBytes;
        }
    }
}
