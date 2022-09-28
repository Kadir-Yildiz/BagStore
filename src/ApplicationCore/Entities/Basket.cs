using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Basket : BaseEntity
    {
        public int BuyerId { get; set; }
        public List<BasketItem> _items  = new List<BasketItem>();
    }
}
