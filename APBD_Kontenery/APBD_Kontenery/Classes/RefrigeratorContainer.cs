namespace APBD_Kontenery.Classes;

public class RefrigeratorContainer(
    double cargoWeight,
    double ownWeight,
    double height,
    double depth,
    double maximumLoad,
    string productType,
    double temperature)
    : Container(cargoWeight, ownWeight, height, depth, maximumLoad, "KON-L " + _containerIndex)
{
    public String ProductType { get; set; } = productType;

    public double Temperature { get; set; } = temperature;

    public override string Description()
    {
        return "Serial Number -> " + SerialNumber + "  " +
               "Cargo Weight -> " + CargoWeight + "  " +
               "Product Type -> " + ProductType + "  " +
               "Temperature -> " + Temperature;
    }

    private Dictionary<string, double> _prodTemp = new Dictionary<string, double>
    {
        { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 }, { "Meat", -15 }, { "Ice Cream", -18 },
        { "Frozen pizza", -30 }, { "Cheese", 7.2 }, { "Sausages", 5 }, { "Butter", 20.5 }, { "Eggs", 19 }
    };
}