using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public class GasContainer : Container , IHazardNotifier
{

    public double Pressure { get; set; }

    public GasContainer(double cargoWeight, double ownWeight, double height, double depth, double maximumLoad, double serialNumber) : base(cargoWeight, ownWeight, height, depth, maximumLoad, serialNumber)
    {
    }


    public GasContainer(double cargoWeight, double ownWeight, double height, double depth, double maximumLoad, double serialNumber, double pressure) : base(cargoWeight, ownWeight, height, depth, maximumLoad, serialNumber)
    {
        Pressure = pressure;
    }

    
    
    public override void LoadCargo(double weight)
    {
        
    }

    public override void Unload()
    {
        CargoWeight = CargoWeight * 0.9;
    }

    public void SendTextNotification(string message)
    {
        Console.WriteLine("Tutaj dopidac metode");
    }
}