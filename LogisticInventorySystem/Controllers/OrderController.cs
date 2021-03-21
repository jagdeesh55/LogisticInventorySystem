using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LogisticInventorySystem.Models;
using Microsoft.AspNetCore.Identity;
using LogisticInventorySystem.Areas.Identity.Data;
using System.Text.RegularExpressions;

namespace LogisticInventorySystem.Controllers
{
    public class OrderController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        private CloudTable getTableStorageInformation()
        {
            //link to appsettings.json and read connection string
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();
            CloudStorageAccount storageaccount = CloudStorageAccount.Parse(configure["ConnectionStrings:TableStorageConnection"]);

            //table creation
            CloudTableClient tableclient = storageaccount.CreateCloudTableClient();
            CloudTable table = tableclient.GetTableReference("supplierorder");

            return table;
        }

        public ActionResult CreateSupplierOrderPage(string msg = null)
        {
            ViewBag.message = msg;
            string orderid = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=","");
            Regex rgx = new Regex("[^a-zA-Z0-9 -]"); 
            orderid = rgx.Replace(orderid, "").Substring(0,5);
            orderid = "SP_" + orderid;
            ViewBag.OrderID = orderid;
            return View();
        }

        public ActionResult PlaceSupplierOrder(string orderid,string itemid, int qty)
        {
            CloudTable tablestorage = getTableStorageInformation();
            OrderEntity order = new OrderEntity(orderid, itemid);
            order.quantity = qty;

            string msg = "";
            
            try
            {
                TableOperation insertOperation = TableOperation.Insert(order);
                TableResult result = tablestorage.ExecuteAsync(insertOperation).Result;
                if(result.HttpStatusCode == 204)
                {
                    msg = "Order ID: "+ orderid+" Succesfully Placed";
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return RedirectToAction("CreateSupplierOrderPage", "Order", new { msg = msg });
        }

        public ActionResult ViewSupplierOrders(string error = null)
        {
            ViewBag.msg = error;
            CloudTable tablestorage = getTableStorageInformation();

            TableQuery<OrderEntity> query = new TableQuery<OrderEntity>();

            List<OrderEntity> all = new List<OrderEntity>();
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<OrderEntity> results = tablestorage.ExecuteQuerySegmentedAsync(query, token).Result;
                token = results.ContinuationToken;

                foreach (OrderEntity order in results.Results)
                {
                    all.Add(order);
                }
            }
            while (token != null);
            if (all.Count != 0)
            {
                return View(all);
            }
            else
            {
                error = "Data not found";
                return RedirectToAction("ViewSupplierOrders", "Order", new { error = error });
            }
        }

        public ActionResult SearchOrderPage(string name, string error = null)
        {
            CloudTable tablestorage = getTableStorageInformation();

            TableQuery<OrderEntity> query = new TableQuery<OrderEntity>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, name));
            List<OrderEntity> all = new List<OrderEntity>();
            TableContinuationToken token = null;

            do
            {
                TableQuerySegment<OrderEntity> results = tablestorage.ExecuteQuerySegmentedAsync(query, token).Result;
                token = results.ContinuationToken;

                foreach (OrderEntity order in results.Results)
                {
                    all.Add(order);
                }
            }
            while (token != null);
            if (all.Count != 0)
            {
                return View(all); 
            }
            else
            {
                error = "No Search Data found for "+name;
                return RedirectToAction("ViewSupplierOrders", "Order", new { error = error });
            }
        }
    }

}
