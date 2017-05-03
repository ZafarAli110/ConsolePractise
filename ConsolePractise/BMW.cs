using System;
using System.Drawing;

public class BMW : BaseCar
{
    public BMW() : base("BMW","M3",2006 , Color.Black)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Starting.....Roar!");
    }

    public override void PressAccelator(double howFar)
    {
        Console.WriteLine("Vrom vrom vrom!!");
    }

    public override void PressBrake(double pressure)
    {
        Console.WriteLine("Stopping....."); ;
    }

    
}
