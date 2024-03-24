
using APBD_Kontenery.Interfaces;

namespace APBD_Kontenery.Classes;

public class LiquidContainer : Container , IHazardNotifier
{
    private IHazardNotifier _hazardNotifierImplementation;

    public bool IsDanegrous { get; set; }

    public LiquidContainer(double cargoWeight, double ownWeight, double height, double depth, double maximumLoad, double serialNumber, bool isDanegrous) : 
        base(cargoWeight, ownWeight, height, depth, maximumLoad, "KON-L"+ _containerIndex)
    {
        IsDanegrous = isDanegrous;
    }
    

   public override void LoadCargo(double weight)
   {
       if (weight > MaximumLoad * 0.5 && IsDanegrous)
       {
           SendTextNotification("cannot load more than 50% of its capacity");
       }
       else if (IsDanegrous == false && weight > MaximumLoad * 0.9 )
       {
           SendTextNotification("cannot load more than 90% of its capacity");
       }
       else if(IsDanegrous == false && weight < MaximumLoad * 0.9 )
       {
           CargoWeight = weight;
       }
       else
       {
           CargoWeight = weight;
       }
   }
   

   public override void Unload()
    {
        CargoWeight = 0;
    }


    public void SendTextNotification(string message)
    {
       Console.WriteLine(message);
    }
}