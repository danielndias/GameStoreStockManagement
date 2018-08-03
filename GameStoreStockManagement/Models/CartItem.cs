using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStoreStockManagement.Models
{
    public class CartItem
    {

        public GamePlatform Item { get; set; }

        public int Quantity { get; set; }
    }
}