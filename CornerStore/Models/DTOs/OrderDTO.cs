namespace CornerStore.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public int CashierId { get; set; }
    public decimal Total
    {
        get
        {
            decimal calculatedTotal = 0M;
            foreach (OrderProductDTO o in OrderProducts)
            {
                calculatedTotal += o.Product.Price * o.Quantity;
            }
            return calculatedTotal;
        }
    }
    public DateTime? PaidOnDate { get; set; }
    public List<OrderProductDTO> OrderProducts { get; set; }
}