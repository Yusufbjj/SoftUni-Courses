using System;

namespace Encapsulation
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                Box box = new Box(l, w, h);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");

            }
            catch (Exception e)
            {
              
            }

        }
    }
}
