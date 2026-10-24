using System.ComponentModel.DataAnnotations;

namespace CornerStore.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    public int CashierId { get; set; }
    public decimal Total
    {
        get
        {
            decimal calculatedTotal = 0M;
            foreach (OrderProduct o in OrderProducts)
            {
                calculatedTotal += o.Product.Price * o.Quantity;
            }
            return calculatedTotal;
        }
    }
    public DateTime? PaidOnDate { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}