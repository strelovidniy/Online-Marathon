namespace Sprint_10.Task_08
{
    public class OrdinaryInvoice : Invoice
    {
        public double GetDiscount(double amount)
            => amount * 0.99;
    }
}
