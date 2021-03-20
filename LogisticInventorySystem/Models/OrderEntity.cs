using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticInventorySystem.Models
{
    public class OrderEntity : TableEntity
    {
        public OrderEntity (string orderid, string itemid)
        {
            this.PartitionKey = orderid;
            this.RowKey = itemid;
        }

        public OrderEntity() { }

        public int quantity { get; set; }
    }
}
