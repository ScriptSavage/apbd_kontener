using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public abstract class Container : IContainers
{
    public double CargoWeight { get; set; }

    public double OwnWeight { get; set; }
    public double Height { get; set; }

    public double Depth { get; set; }

    public double MaximumLoad { get; set; }


    public double SerialNumber { get; set; }


    protected Container(double cargoWeight, double ownWeight, double height, double depth, double maximumLoad, double serialNumber)
    {
        CargoWeight = cargoWeight;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        MaximumLoad = maximumLoad;
        SerialNumber = serialNumber;
    }


    public abstract void LoadCargo(double weight);
    public abstract void Unload();


    public void CheckOverfill(double wight)
    {
        if (wight >= MaximumLoad)
        {
            throw new OverFillException("Za duza waga ladunku");
        }
    }


}