using System;
using System.Drawing;
public class Toyota : BaseCar
{
    public Toyota() :base("Toyota","Toyota Coralla",2005,Color.Silver)
    {

    }

    public override void PressAccelator(double howFar)
    {
        Console.WriteLine("Click click click...");
    }

    public override void PressBrake(double pressure)
    {
        if (pressure < 5)
        {
            // nothing happens
        }
        else
            Console.WriteLine("break applied....");
    }

    public override void Start()
    {
        Console.WriteLine("Starting....vom vom");
    }
}
