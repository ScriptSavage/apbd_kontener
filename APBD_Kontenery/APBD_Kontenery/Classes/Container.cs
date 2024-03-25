using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public abstract class Container : IHazardNotifier
{

    protected static int _containerIndex = 1;

    protected int _id { get; } = _containerIndex++;
    public double CargoWeight { get; set; }

    public double OwnWeight { get; set; }
    public double Height { get; set; }

    public double Depth { get; set; }

    public double MaximumLoad { get; set; }


    public string SerialNumber { get; set; }


    protected Container(double cargoWeight, double ownWeight, double height, double depth, double maximumLoad, string serialNumber)
    {
        CargoWeight = cargoWeight;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        MaximumLoad = maximumLoad;
        SerialNumber = serialNumber;
    }

    public void CheckOverfill(double wight)
    {
        if (wight >= MaximumLoad)
        {
            throw new OverFillException("Za duza waga ladunku");
        }
    }

    public virtual string Description()
    {
        return "Default Description";
    }


    public void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double weight)
    {
        if (weight < 0 || weight > MaximumLoad)
        {
            throw new Exception("Nieprawidlowa masa");
        }
        else
        {
            CargoWeight = weight;
        }
       
    }

    public void SendTextNotification(string message)
    {
        Console.WriteLine("Wiadomosc");
    }
}