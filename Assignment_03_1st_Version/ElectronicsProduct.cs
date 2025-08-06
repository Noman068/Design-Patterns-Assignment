public class ElectronicsProduct : Product
{
    public int WarrantyMonths;

    public override string GetProductDetails()
    {
        return "Electronics - " + Name + " | $" + Price + " | Warranty: " + WarrantyMonths + " months";
    }
}

