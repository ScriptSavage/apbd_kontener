namespace APBD_Kontenery.Classes;

public class Program
{
    public static void Main(string[] args)
    {

        GasContainer g = new GasContainer(0, 100, 100, 100, 200, 90);
Console.WriteLine(g.Description());

        LiquidContainer l = new LiquidContainer(80, 100, 20, 30, 300, true);

Console.WriteLine(l.Description());



RefrigeratorContainer r = new RefrigeratorContainer(70, 100, 30, 30, 50, "fruits", 5);

Console.WriteLine(r.Description());

Ship s = new Ship(100, 900, 10000);






    }
}