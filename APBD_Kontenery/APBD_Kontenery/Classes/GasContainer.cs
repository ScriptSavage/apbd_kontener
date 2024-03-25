using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public class GasContainer(
    double cargoWeight,
    double ownWeight,
    double height,
    double depth,
    double maximumLoad,
    double pressure)
    : Container(cargoWeight, ownWeight, height, depth, maximumLoad, "KON-L " + _containerIndex), IHazardNotifier
{

    public double Pressure { get; set; }
    public override string Description()
    {
        return "Serial Number -> " + SerialNumber + " "+ 
               "Cargo Weight -> " + CargoWeight + " " +
               "Pressure -> " + pressure;
    } 

    public new void Unload()
    {
        CargoWeight = CargoWeight * 0.05;
        base.Unload();
    }

    public void SendTextNotification(string message)
    {
        Console.WriteLine("Za duza masa");
    }
}