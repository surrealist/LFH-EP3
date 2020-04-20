using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EP3.Models
{
  public class Order
  {
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }
     = DateTime.Now;

    [Required]
    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderDetail> LineItems { get; set; }
      = new HashSet<OrderDetail>();

  }
}
