using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace EBookCart.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }
        
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int OrderStatusID { get; set; }
        
        public bool IsDeleted { get; set; } = false;

        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
