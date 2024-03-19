using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public abstract class Container : IContainers
{
    private double _cargoWeight;


    public  double CargoWeight { get; set; }

    protected Container(double cargoWeight)
    {
        cargoWeight = cargoWeight;
    }

    public void LoadCargo(double weight)
    {
        throw new NotImplementedException("");
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }
}