using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public class GasContainer(
    double cargoWeight,
    double ownWeight,
    double height,
    double depth,
    double maximumLoad,
    string serialNumber,
    double pressure)
    : Container(cargoWeight, ownWeight, height, depth, maximumLoad, serialNumber), IHazardNotifier
{

    public double Pressure { get; set; } = pressure;


    public override void LoadCargo(double weight)
    {
        if (weight > maximumLoad)
        {
            SendTextNotification("Za duza masa");
        }
        
    }

    public override void Unload()
    {
        CargoWeight = CargoWeight * 0.05;
    }

    public void SendTextNotification(string message)
    {
        Console.WriteLine("Za duza masa");
    }
}