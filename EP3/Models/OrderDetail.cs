using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EP3.Models
{
  // [Table("OrderDetails")]
  public class OrderDetail
  { 

    public int Id { get;  set; }

    public double Quantity { get; set; }

    //[Required]
    //public virtual Order Order { get; set; }

    [Required]
    public virtual Product Item { get; set; }

    public decimal Total => (decimal)Quantity * Item.Price;

  }
}
