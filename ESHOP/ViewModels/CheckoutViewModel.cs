using ESHOP.Models;

namespace ESHOP.ViewModels
{
    public class CheckoutViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public PaymentInfoViewModel PaymentInfo { get; set; }
    }
}
