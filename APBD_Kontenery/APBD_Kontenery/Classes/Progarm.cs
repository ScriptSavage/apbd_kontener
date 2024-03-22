namespace APBD_Kontenery.Classes;

public class Program
{
    public static void Main(string[] args)
    {

        LiquidContainer a = new LiquidContainer(90, 12, 45, 50, 100, 23,false);
        
        a.LoadCargo(80);
        
        Console.WriteLine(a.CargoWeight);
        
        a.Unload();
        
        Console.WriteLine(a.CargoWeight);

        
        
        
    }
}