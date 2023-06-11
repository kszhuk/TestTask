using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Infrastructure.DataModels
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(40)]
        public string Material { get; set; }

        [Precision(8, 3)]
        public decimal Quantity { get; set; }
    }
}
