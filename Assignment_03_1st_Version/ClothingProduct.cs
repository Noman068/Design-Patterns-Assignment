public class ClothingProduct : Product
{
    public string Size;

    public override string GetProductDetails()
    {
        return "Clothing - " + Name + " | $" + Price + " | Size: " + Size;
    }
}