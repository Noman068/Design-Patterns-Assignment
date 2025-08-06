public class HomeGardenProduct : Product
{
    public string Material;

    public override string GetProductDetails()
    {
        return "HomeGarden - " + Name + " | $" + Price + " | Material: " + Material;
    }
}