using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EP3.Models
{
  public class Customer
  {
    //[Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } 
      = new HashSet<Order>();
  }
}
