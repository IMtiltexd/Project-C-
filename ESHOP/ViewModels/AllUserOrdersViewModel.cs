using ESHOP.Models;

public class AllUserOrdersViewModel
{
    public string UserEmail  { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}