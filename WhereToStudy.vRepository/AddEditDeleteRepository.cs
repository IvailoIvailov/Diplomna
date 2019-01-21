using Warehouse.vModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vRepository
{
    public class AddEditDeleteRepository : BaseRepository
    {
        #region Type
        public Types GetType(int id)
        {
            return QueryFirst<Types>("GetType", new { @pId = id });
        }

        public List<Types> GetTypes()
        {
            return QueryMultiple<Types>("GetTypes");
        }

        public Types InsertType(Types type)
        {
            return QueryFirst<Types>("InsertType",
                new
                {
                    @pName = type.Name
                });
        }
        public Types UpdateType(Types type)
        {
            return QueryFirst<Types>("UpdateType",
                new
                {
                    @pId = type.Id,
                    @pName = type.Name
                });
        }

        public Types DeleteType(int id)
        {
            return QueryFirst<Types>("DeleteType", new { @pId = id });
        }
        #endregion

        #region Item
        public Item GetItem(int id)
        {
            return QueryFirst<Item>("GetItem", new { @pId = id });
        }

        public List<Item> GetItems()
        {
            return QueryMultiple<Item>("GetItems");
        }

        public Image GetItemImage(int itemId)
        {
            return QueryFirst<Image>("spGetImage",
                new
                {
                    @itemId = itemId
                });
        }

        public Item InsertItem(Item item)
        {
            return QueryFirst<Item>("InsertItem",
                new
                {
                    
                    @pName = item.Name
                    ,
                    @pCode = item.Code
                    ,
                    @pSalePrice = item.SalePrice
                    ,
                    @pPrice = item.Price
                    ,
                    @pQuantity = item.Quantity
                    ,
                    @pGroupId = item.GroupId
                    ,
                    @pTypeId = item.TypeId
                });
        }
        public Item UpdateItem(Item item)
        {
            return QueryFirst<Item>("UpdateItem",
                new
                {
                    @pId = item.Id
                    ,
                    @pName = item.Name
                    ,
                    @pCode = item.Code
                    ,
                    @pSalePrice = item.SalePrice
                    ,
                    @pPrice = item.Price
                    ,
                    @pQuantity = item.Quantity
                    ,
                    @pGroupId = item.GroupId
                    ,
                    @pTypeId = item.TypeId
                });
        }

        public Item DeleteItem(int id)
        {
            return QueryFirst<Item>("DeleteItem", new { @pId = id });
        }

        public Item GetItemByName(string name)
        {
            return QueryFirst<Item>("GetItemByName", new { @pname = name });
        }

        public List<Item> GetItemsByType(int typeId)
        {
            return QueryMultiple<Item>("GetItemsByType", new { @ptypeId = typeId });
        }

        public List<Operation> GetOperationByCientId(int clientId)
        {
            return QueryMultiple<Operation>("GetOperationByCientId", new { @pClientId = clientId });
        }

        public List<Operation> GetOperationsByDate(DateTime? date)
        {
            return QueryMultiple<Operation>("GetOperationsByDate", new { @pDate = date });
        }


        #endregion

        #region Client
        public Client GetClient(int id)
        {
            return QueryFirst<Client>("GetClient", new { @pId = id });
        }

        public List<Client> GetClients()
        {
            return QueryMultiple<Client>("GetClients");
        }

        public Client InsertClient(Client client)
        {
            return QueryFirst<Client>("InsertClient",
                new
                {
                    @pName = client.Name
                    ,
                    @pBulstat = client.Bulstat,
                    @pCode = client.Code,
                    @pAddress = client.Address,
                    @pFaks = client.Faks,
                    @pPhone = client.Phone
                });
        }
        public Client UpdateClient(Client client)
        {
            return QueryFirst<Client>("UpdateClient",
                new
                {
                    @pId = client.Id
                    ,
                    @pName = client.Name
                    ,
                    @pBulstat = client.Bulstat,
                    @pCode = client.Code,
                    @pAddress = client.Address,
                    @pFaks = client.Faks,
                    @pPhone = client.Phone
                });
        }

        public Client DeleteClient(int id)
        {
            return QueryFirst<Client>("DeleteClient", new { @pId = id });
        }
        #endregion

        #region Groups
        public Groups GetGroup(int id)
        {
            return QueryFirst<Groups>("GetGroup", new { @pId = id });
        }

        public List<Groups> GetGroups()
        {
            return QueryMultiple<Groups>("GetGroups");
        }

        public Groups InsertGroup(Groups group)
        {
            return QueryFirst<Groups>("InsertGroup",
                new
                {
                    @pName = group.Name
                });
        }
        public Groups UpdateGroups(Groups group)
        {
            return QueryFirst<Groups>("UpdateGroup",
                new
                {
                    @pId = group.Id
                    ,
                    @pName = group.Name
                });
        }

        public Groups DeleteGroups(int id)
        {
            return QueryFirst<Groups>("DeleteGroup", new { @pId = id });
        }
        #endregion

        #region OperationType
        public OperationType GetOperationType(int id)
        {
            return QueryFirst<OperationType>("GetOperationType", new { @pId = id });
        }

        public List<OperationType> GetOperationTypes()
        {
            return QueryMultiple<OperationType>("GetOperationTypes");
        }

        public OperationType InsertOperationType(OperationType opr)
        {
            return QueryFirst<OperationType>("InsertOperationType",
                new
                {
                    @pName = opr.Name
                });
        }
        public OperationType UpdateOperationType(OperationType opr)
        {
            return QueryFirst<OperationType>("UpdateOperationType",
                new
                {
                    @pId = opr.Id
                    ,
                    @pName = opr.Name
                });
        }

        public OperationType DeleteOperationType(int id)
        {
            return QueryFirst<OperationType>("DeleteOperationType", new { @pId = id });
        }
        #endregion

        #region PaymentType
        public PaymentType GetPaymentType(int id)
        {
            return QueryFirst<PaymentType>("GetPaymentType", new { @pId = id });
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return QueryMultiple<PaymentType>("GetPaymentTypes");
        }

        public PaymentType InsertPaymentType(PaymentType opr)
        {
            return QueryFirst<PaymentType>("InsertPaymentType",
                new
                {
                    @pName = opr.Name
                });
        }
        public PaymentType UpdatePaymentType(PaymentType opr)
        {
            return QueryFirst<PaymentType>("UpdatePaymentType",
                new
                {
                    @pId = opr.Id
                    ,
                    @pName = opr.Name
                });
        }

        public PaymentType DeletePaymentType(int id)
        {
            return QueryFirst<PaymentType>("DeletePaymentType", new { @pId = id });
        }
        #endregion

        #region OperationDetail
        public List<OperationDetail> GetOperationDetail(int id)
        {
            return QueryMultiple<OperationDetail>("GetOperationDetail", new { @pId = id });
        }

        public List<OperationDetail> GetOperationDetails()
        {
            return QueryMultiple<OperationDetail>("GetOperationDetails");
        }

        public OperationDetail InsertOperationDetail(OperationDetail operation)
        {
            return QueryFirst<OperationDetail>("InsertOperationDetail",
                new
                {
                    @pItemId = operation.ItemId
                    ,
                    @pQuantity = operation.Quantity
                    ,
                    @pSalePrice = operation.SalePrice
                     ,
                    @pRowSum = operation.RowSum
                    ,
                    @pOperationId = operation.OperationId
                });
        }

        public OperationDetail DeleteOperationDetail(int id)
        {
            return QueryFirst<OperationDetail>("DeleteOperation", new { @pId = id });
        }
        #endregion

        #region Operation
        public Operation GetOperation(int id)
        {
            return QueryFirst<Operation>("GetOperation", new { @pId = id });
        }

        public List<Operation> GetOperations()
        {
            return QueryMultiple<Operation>("GetOperations");
        }

        public List<Operation> GetOperationByDate(DateTime? date)
        {
            return QueryMultiple<Operation>("GetOperationByDate", new { @pdate = date });
        }

        public List<Operation> GetOperationByClient(DateTime? date)
        {
            return QueryMultiple<Operation>("GetOperationByClient", new { @pdate = date });
        }

        public Operation InsertOperation(Operation operation)
        {
            return QueryFirst<Operation>("InsertOperation",
                new
                {
                    @pDate = operation.Date
                    ,
                    @pPartnerId = operation.PartnerId
                    ,
                    @pAmount = operation.Amount,

                    @pOperationTypeId = operation.OperationTypeId
                });
        }
        public Operation UpdateOperation(Operation operation)
        {
            return QueryFirst<Operation>("UpdateOperation",
                new
                {
                    @pId = operation.Id
                    ,
                    @pDate = operation.Date
                    ,
                    @pPartnerId = operation.PartnerId
                    ,
                    @pAmount = operation.Amount
                });
        }

        public Operation DeleteOperation(int id)
        {
            return QueryFirst<Operation>("DeleteOperation", new { @pId = id });
        }
        #endregion

        public Image InsertImage(Image image)
        {
            return QueryFirst<Image>("spInsertImage", new
            {
                @id = image.Id,
                @name = image.Name,
                @data = image.Data,
                @length = image.Length,
                @contentType = image.ContentType,
                @itemId = image.ItemId
            });
        }
    }
}
