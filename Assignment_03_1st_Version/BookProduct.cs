public class BookProduct : Product
{
    public string ISBN;

    public override string GetProductDetails()
    {
        return "Book - " + Name + " | $" + Price + " | ISBN: " + ISBN;
    }
}