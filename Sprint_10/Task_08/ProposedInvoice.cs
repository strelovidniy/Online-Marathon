namespace Sprint_10.Task_08
{
    public class ProposedInvoice : Invoice
    {
        public double GetDiscount(double amount)
            => amount * 0.95;
    }
}
