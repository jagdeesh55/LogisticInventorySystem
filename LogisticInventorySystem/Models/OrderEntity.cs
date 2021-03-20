using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticInventorySystem.Models
{
    public class OrderEntity : TableEntity
    {
        public OrderEntity (string orderid, int itemid)
        {
            this.PartitionKey = orderid;
            this.RowKey = itemid.ToString();
        }

        public OrderEntity() { }

        public int quantity { get; set; }
    }
}
